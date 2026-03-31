using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OptionA.Blazor.Blog;

namespace OptionA.Site.Shared
{
    public partial class ComponentTester
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; } = default!;
        [Parameter]
        public string ComponentName { get; set; } = string.Empty;
        [Parameter]
        public RenderFragment? Component { get; set; }
        [Parameter]
        public RenderFragment? Parameters { get; set; }
        [Parameter]
        public RenderFragment? Result { get; set; }
        [Parameter]
        public string? AdditionalClasses { get; set; }
        [Parameter]
        public EventCallback<string?> AdditionalClassesChanged { get; set; }
        [Parameter]
        public List<string>? RemovedClasses { get; set; }
        [Parameter]
        public EventCallback<List<string>?> RemovedClassesChanged { get; set; }
        [Parameter]
        public Dictionary<string, object?>? Attributes { get; set; }
        [Parameter]
        public EventCallback<Dictionary<string, object?>?> AttributesChanged { get; set; }

        private string? InternalAdditionalClasses
        {
            get => AdditionalClasses;
            set
            {
                if (!string.Equals(AdditionalClasses, value))
                {
                    AdditionalClasses = value;
                    if (AdditionalClassesChanged.HasDelegate)
                    {
                        AdditionalClassesChanged.InvokeAsync(value);
                    }
                }
            }
        }

        private string? InternalRemovedClasses
        {
            get => RemovedClasses != null ? string.Join(' ', RemovedClasses) : null;
            set
            {
                var current = RemovedClasses != null ? string.Join(' ', RemovedClasses) : null;
                if (!string.Equals(current, value))
                {
                    RemovedClasses = value?
                        .Split(' ')
                        .ToList();
                    if (RemovedClassesChanged.HasDelegate)
                    {
                        RemovedClassesChanged.InvokeAsync(RemovedClasses);
                    }
                }
            }
        }

        private List<string>? _attributesFlat;
        private string? InternalAttributes
        {
            get => _attributesFlat != null ? string.Join(' ', _attributesFlat) : null;
            set
            {
                var current = _attributesFlat != null ? string.Join(' ', _attributesFlat) : null;
                if (!string.Equals(current, value))
                {
                    _attributesFlat = value?
                        .Split(' ')
                        .ToList();
                    Attributes = _attributesFlat?
                        .Select(x => x.Split('=', 2, StringSplitOptions.RemoveEmptyEntries))
                        .Where(x => x.Length == 2)
                        .ToDictionary(x => x[0], x => (object?)x[1]);
                    if (AttributesChanged.HasDelegate)
                    {
                        AttributesChanged.InvokeAsync(Attributes);
                    }
                }
            }
        }

        
        
        
        private ElementReference _container;
        private CodeContent? _content;
        private Lazy<Task<IJSObjectReference>>? _moduleTask;


        public async Task GetHtml()
        {
            if (_moduleTask == null)
            {
                return;
            }

            var module = await _moduleTask.Value;
            var html = await module.InvokeAsync<string>("getHtml", _container);

            if (_content != null && _content.Code == html)
            {
                return;
            }

            // Format the HTML to be more readable
            html = FormatHtml(html);


            _content = new CodeContent
            {
                Code = html,
                Language = CodeLanguage.Html
            };
            await InvokeAsync(StateHasChanged);
        }


        protected override void OnInitialized()
        {
            _moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>("import", "./Shared/ComponentTester.razor.js").AsTask());
        }

        private string FormatHtml(string html)
        {
            html = html
                .Replace("<!--!-->", string.Empty)
                .Replace("><", ">\n<")
                .Replace("</", "\n</");

            return html;
        }
    }
}
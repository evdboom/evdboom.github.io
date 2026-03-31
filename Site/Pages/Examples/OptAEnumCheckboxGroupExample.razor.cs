using OptionA.Site.Examples;
using OptionA.Site.Shared;
using OptionA.Blazor.Components;

namespace OptionA.Site.Pages.Examples
{
    public partial class OptAEnumCheckboxGroupExample
    {
        private IEnumerable<ExampleEnum>? _selectedEnums;
        private bool _shouldGetHtml;

        private string? _additionalClasses;
        private string? AdditionalClasses 
        { 
            get => _additionalClasses;
            set
            {
                if (!string.Equals(_additionalClasses,value))
                {
                    _additionalClasses = value;
                    _shouldGetHtml = true;
                }
            }
        }

        private List<string>? _removedClasses;
        private List<string>? RemovedClasses
        {
            get => _removedClasses;
            set
            {
                if (_removedClasses == null && value == null)
                {
                    return;
                }
                else if ((_removedClasses == null && value != null) || (RemovedClasses != null && value == null))
                {
                    _removedClasses = value; 
                    _shouldGetHtml = true;
                    return;
                }
                else if (_removedClasses!.SequenceEqual(value!))
                {
                    return;
                }
                else
                {
                    _removedClasses = value;
                    _shouldGetHtml = true;
                }             
            }
        }

        private Dictionary<string, object?>? _attributes;
        private Dictionary<string, object?>? Attributes
        {
            get => _attributes;
            set
            {
                if (_attributes == null && value == null)
                {
                    return;
                }
                else if ((_attributes == null && value != null) || (_attributes != null && value == null))
                {
                    _attributes = value;
                    _shouldGetHtml = true;
                    return;
                }
                else if (_attributes!.Count != value!.Count)
                {
                    _attributes = value;
                    _shouldGetHtml = true;
                    return;
                }
                else
                {
                    foreach (var kvp in _attributes)
                    {
                        if (!value!.TryGetValue(kvp.Key, out var v) || !Equals(v, kvp.Value))
                        {
                            _attributes = value;
                            _shouldGetHtml = true;
                            return;
                        }
                    }
                }
            }
        }

        private bool _orderDescending;
        private bool OrderDescending
        {
            get => _orderDescending;
            set
            {
                if (_orderDescending != value)
                {
                    _orderDescending = value;
                    _shouldGetHtml = true;
                }
            }
        }
        private EnumOrder _orderMode;
        private EnumOrder OrderMode
        {
            get => _orderMode;
            set
            {
                if (_orderMode != value)
                {
                    _orderMode = value;
                    _shouldGetHtml = true;
                }
            }
        }

        private Orientation _orientation;
        private Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    _shouldGetHtml = true;
                }
            }
        }
        private bool _useMappings;
        private bool UseMappings
        {
            get => _useMappings;
            set
            {
                if (_useMappings != value)
                {
                    _useMappings = value;
                    _shouldGetHtml = true;
                }
            }
        }

        private ComponentTester? _tester;

        private Dictionary<ExampleEnum, string>? NameMappings => _useMappings
            ? ExampleData.EnumNameMappings
            : null;
        private Dictionary<ExampleEnum, string>? TitleMappings => _useMappings
            ? ExampleData.EnumTitleMappings
            : null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && _tester != null)
            {
                await _tester.GetHtml();
            }
            if (_shouldGetHtml && _tester != null)
            {
                _shouldGetHtml = false;
                await _tester.GetHtml();
            }
        }
    }
}
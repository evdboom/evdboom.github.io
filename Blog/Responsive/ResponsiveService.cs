using Microsoft.JSInterop;

namespace Blog.Responsive
{
    public class ResponsiveService : IResponsiveService
    {
        private const string RegisterHandlerFunction = "registerHandler";
        private const string GetDimensionFunction = "getDimension";

        private SizedDimension? _currentDimension;
        private bool _initialized;

        public event EventHandler<SizedDimension>? OnWindowSizeChanged;
        public event EventHandler<MediaSize>? OnDimensionSizeChanged;

        private readonly MediaSize[] _bootstrapBreakPoints;

        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public bool Initialized => _initialized;

        public ResponsiveService(IJSRuntime jsRuntime)
        {
            _bootstrapBreakPoints = Enum
                .GetValues<MediaSize>()
                .OrderBy(s => (int)s) // better safe then sorry
                .ToArray();

            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
              "import", "./js/responsive-service.js").AsTask());
        }

        public async Task<SizedDimension> GetWindowSizeAsync()
        {
            await InitializeAsync();
            return _currentDimension!;
        }

        public SizedDimension GetWindowSize()
        {
            if (!_initialized)
            {
                throw new InvalidOperationException("Initialize service first");
            }

            return _currentDimension!;
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }
            
            var module = await _moduleTask.Value.ConfigureAwait(false);
            var objRef = DotNetObjectReference.Create(this);
            var dimension = await module.InvokeAsync<Dimension>(GetDimensionFunction).ConfigureAwait(false);
            var mediaSize = MediaSize(dimension.Width);
            _currentDimension = new SizedDimension { MediaSize = mediaSize, Height = dimension.Height, Width = dimension.Width };

            await module.InvokeVoidAsync(RegisterHandlerFunction, objRef, nameof(WindowSizeChanged)).ConfigureAwait(false);
            _initialized = true;
        }
     
        [JSInvokable]
        public void WindowSizeChanged(Dimension dimension)
        {
            if (dimension is null)
            {
                return;
            }

            var mediaSize = MediaSize(dimension.Width);

            if (_currentDimension?.MediaSize != mediaSize)
            {
                OnDimensionSizeChanged?.Invoke(this, mediaSize);
            }

            _currentDimension = new SizedDimension { MediaSize = mediaSize, Height = dimension.Height, Width = dimension.Width };

            OnWindowSizeChanged?.Invoke(this, _currentDimension);
        }

        private MediaSize MediaSize(int width)
        {
            return _bootstrapBreakPoints
                .First(b => width >= (int)b);
        }
    }
}

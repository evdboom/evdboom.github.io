namespace Blog.Responsive
{
    public interface IResponsiveService
    {
        public interface IResponsiveService
        {
            event EventHandler<SizedDimension>? OnWindowSizeChanged;
            event EventHandler<MediaSize>? OnDimensionSizeChanged;
            Task<SizedDimension> GetWindowSizeAsync();
            SizedDimension GetWindowSize();
        }
    }
}

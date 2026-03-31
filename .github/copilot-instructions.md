# Copilot Instructions for evdboom.github.io

## Razor Component Structure

### File Organization
For each Razor component, maintain **separate files** for logic, styling, and markup:

```
Component/
├── MyComponent.razor          (markup only - keep minimal, <50 lines ideally)
├── MyComponent.razor.cs       (code-behind logic)
├── MyComponent.razor.scoped.css (component-specific styles)
└── MyComponent.razor.js       (if component-specific interop needed)
```

### Razor Component Rules
- **Component file (.razor)**: Contains only markup and directives (`@using`, `@layout`, `@page`, etc.)
- **No inline C# code blocks** (`@{ }`) in component files - move to `.razor.cs`
- **No inline `<style>` tags** - move all CSS to `.razor.css`
- **No inline `<script>` tags** - move to `.razor.js` if needed
- Keep `.razor` files under 50 lines when possible

**Example - Good:**
```razor
<!-- MyComponent.razor -->
<div class="my-component">
    <h3 class="component-title">@Title</h3>
    <p>@Description</p>
</div>
```

```csharp
// MyComponent.razor.cs
public partial class MyComponent : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
    
    [Parameter]
    public string Description { get; set; }
}
```

```css
/* MyComponent.razor.scoped.css */
.my-component {
    padding: 1rem;
    border: 1px solid #e0e0e0;
}

.component-title {
    font-weight: bold;
    color: #667eea;
}
```

## Project Organization

### Directory Structure
```
Site/
├── Project/              (Project specific razor components)
│   ├── Bindery/
│   │   ├── Project.razor
│   │   ├── Project.razor.cs
│   │   ├── Project.razor.css
│   │   ├── Privacy.razor
│   │   ├── Privacy.razor.cs
│   │   └── Privacy.razor.css
│   └── Shared/
├── Pages/                   (Routable pages)
├── Shared/                  (Layout components)
└── wwwroot/
    ├── css/
    │   ├── app.css          (global styles)
    │   └── bootstrap.css    (third-party)
    └── js/                  (global scripts)
```

### File Naming Conventions
- **Components**: PascalCase (`MyComponent.razor`)
- **Code-behind**: `ComponentName.razor.cs`
- **Styles**: `ComponentName.razor.css` (for scoped) or in shared `css/` folder (for global)
- **Scripts**: `ComponentName.razor.js` (component-specific) or in `wwwroot/js/` (global)

## Class & Code Organization

### Single Responsibility Principle
- **One component per file** - don't bundle multiple components
- **One responsibility per class** - keep classes focused and small
- **Max file size**: 300-400 lines (including comments)
- **Max method size**: 50-75 lines (refactor complex logic into smaller methods)

### Naming Conventions
- **Public properties/methods**: `PascalCase`
- **Private fields**: `_camelCase`
- **Constants**: `UPPER_SNAKE_CASE`
- **Classes**: Noun-based (`UserService`, `BookRepository`)
- **Interfaces**: `IPrefixedInterface` (e.g., `ISearchProvider`)
- **Methods**: Verb-based (`GetBooks()`, `ValidateInput()`, `HandleClick()`)

## CSS Guidelines

### Scoped Styles
- Use `component.razor.css` for component-specific styles
- Scoped CSS is automatically namespaced - no naming conflicts
- Keep component styles **under 100 lines** (refactor if larger)

### Global Styles
- Keep in `wwwroot/css/app.css` or dedicated files in `wwwroot/css/`
- Use BEM (Block Element Modifier) naming for shared components:
  ```css
  .block { }
  .block__element { }
  .block--modifier { }
  ```

### CSS Best Practices
- Use CSS variables for theme colors:
  ```css
  :root {
      --primary-color: #667eea;
      --secondary-color: #764ba2;
  }
  
  .button {
      background-color: var(--primary-color);
  }
  ```
- Avoid `!important` (except for utility overrides)
- Use flexbox/grid over floats
- Keep specificity low (target with classes, not element types)

## Code-Behind Organization

### Partial Classes
Always use `public partial class` for Razor code-behind:

```csharp
public partial class MyComponent : ComponentBase
{
    // Parameters first
    [Parameter]
    public string Title { get; set; }

    // Injected services
    [Inject]
    public ILogger<MyComponent> Logger { get; set; }

    // State properties
    private List<string> items = new();

    // Lifecycle methods (in order: OnInitialized, OnParametersSet, OnAfterRender)
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    // Event handlers
    private void HandleClick()
    {
        // ...
    }

    // Helper methods
    private async Task LoadData()
    {
        // ...
    }
}
```

### Method Organization Order
1. Parameters (`[Parameter]`)
2. Injected services (`[Inject]`)
3. Public properties/fields
4. Private fields
5. Lifecycle methods (OnInitialized → OnParametersSet → OnAfterRender)
6. Event handlers
7. Helper methods

## Blazor-Specific Practices

### Component Parameters
- Always mark with `[Parameter]`
- Use `[SupplyParameterFromQuery]` for query strings
- Validate parameters in `OnParametersSet()`
- Document with XML comments

### Services & Dependency Injection
- Inject via `[Inject]` attribute
- Keep services singleton/scoped as appropriate
- Use interfaces for testability

### Interop & JavaScript
- Minimize JavaScript usage
- Keep interop in separate `.razor.js` files
- Use module-based imports (ES6 modules)

## Documentation

### XML Comments
Use XML comments for public members:

```csharp
/// <summary>
/// Searches for books matching the query.
/// </summary>
/// <param name="query">The search query string.</param>
/// <returns>A list of matching books.</returns>
public List<Book> SearchBooks(string query)
{
    // ...
}
```

### Component Documentation
Add `@* *@` comments in `.razor` files only when needed:

```razor
@* Main hero section with gradient background *@
<section class="hero-section">
    <!-- markup -->
</section>
```

## Refactoring Checklist

When writing or modifying code, ask:

- [ ] Is the component file under 50 lines? (Move logic to `.razor.cs`)
- [ ] Are all styles in a `.razor.css` file?
- [ ] Does the class have a single responsibility?
- [ ] Are methods under 75 lines each?
- [ ] Are parameter names clear and documented?
- [ ] Is there repeated code that could be extracted?
- [ ] Are magic strings/numbers replaced with constants?
- [ ] Does the code follow naming conventions?
- [ ] Are public methods XML-documented?

## Examples to Follow

### Good: Separated Concerns
✅ **Project.razor** - Markup with Bootstrap layout  
✅ **Project.razor.cs** - Component logic and parameters  
✅ **Project.razor.css** - Hover effects, transitions, layout tweaks

### Avoid: Inline Code & Styles
❌ Mixing `<style>` tags in `.razor` files  
❌ C# logic (`@{ }` blocks) in markup  
❌ Component-specific styles in global `app.css`  
❌ Files exceeding 300+ lines

## References

- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [ASP.NET Core Code Analysis Rules](https://learn.microsoft.com/dotnet/fundamentals/code-analysis/style-rules/)
- [BEM CSS Naming](https://getbem.com/)
- [Bootstrap Utility Classes](https://getbootstrap.com/docs/5.0/utilities/)

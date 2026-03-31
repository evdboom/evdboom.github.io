namespace OptionA.Site.Pages
{
    public partial class About
    {
        private readonly DateTime _birthDate = new(1983, 8, 4);

        private string GetAge()
        {
            var today = DateTime.Today;
            return today.Month < _birthDate.Month
                || (today.Month == _birthDate.Month && today.Day < _birthDate.Day)
                ? $"{today.Year - _birthDate.Year - 1}"
                : $"{today.Year - _birthDate.Year}";
        }
    }
}

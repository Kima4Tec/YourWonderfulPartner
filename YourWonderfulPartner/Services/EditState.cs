using YourWonderfulPartner.Components.Pages;

namespace YourWonderfulPartner.Services
{
    public class EditState
    {
        public bool IsAdmin { get; set; } = true;
        public bool _isInitialized { get; set; }
        public string? Username { get; set; }
    }
}

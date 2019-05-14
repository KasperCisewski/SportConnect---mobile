using SportConnect.Core.Model.UserData;

namespace SportConnect.Core.Services.GlobalStateService.Abstraction
{
    public interface IGlobalStateService
    {
        AuthorizationTokenUserModel UserData { get; set; }
    }
}

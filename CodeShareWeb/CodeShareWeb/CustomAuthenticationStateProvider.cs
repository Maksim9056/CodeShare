namespace CodeShareWeb
{
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Возвращает текущего пользователя (по умолчанию - анонимного)
            return Task.FromResult(new AuthenticationState(_currentUser));
        }
        public void SignIn(string userEmail, string roleName)
        {
            var claims = new List<Claim>
            {
             new Claim(ClaimTypes.Name, userEmail),
             new Claim(ClaimTypes.Role, roleName)
            };

            var identity = new ClaimsIdentity(claims, authenticationType: "CustomAuth");
            _currentUser = new ClaimsPrincipal(identity);

            // Уведомляем об изменении состояния авторизации
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        //public void SignIn(string userEmail, string roleName)
        //{
        //    // Создаем список клеймов для аутентифицированного пользователя
        //    var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, userEmail),
        //    new Claim(ClaimTypes.Role, roleName)
        //};

        //    var identity = new ClaimsIdentity(claims, "CustomAuth");
        //    _currentUser = new ClaimsPrincipal(identity);

        //    // Уведомляем об изменении состояния
        //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        //}

        public void SignOut()
        {
            // Возвращаем анонимного пользователя
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }


}

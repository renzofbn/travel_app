using System;
using System.Threading.Tasks;
using travellApp;
using travellApp.Droid;
using Firebase.Auth;
using Xamarin.Forms;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(AuthDroid))]
namespace travellApp.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                if (user != null && user.User != null)
                {
                    var uid = user.User.Uid;
                    var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
                    return token.Token;
                }
                else
                {
                    // Manejo de error o registro de información en caso de usuario nulo
                    return "";
                }
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public bool IsSignIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return user.User.Uid;
            }catch(Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return "";
            }
        }

        public void SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar sesión: {ex.Message}");
            }
        }
    }
}
using System;
using System.Threading.Tasks;

namespace travellApp
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);

        bool IsSignIn();

        Task<string> SignUpWithEmailPassword(string email, string password);

        void SignOut();

    }
}
using System;
using System.Threading.Tasks;
using Nhom2vip.Service;
using Nhom2vip.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Nhom2vip.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }
        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Thành công", "Đăng ký thành công", "Đồng ý");
                else
                    await Application.Current.MainPage.DisplayAlert("Lỗi",
                        "Người dùng đã tồn tại với thông tin đăng nhập này", "Đồng ý");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", ex.Message, "Đồng ý");

            }
            finally
            {
                IsBusy = false;
            }
        }

        

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                   

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Lỗi", "Tên đăng nhập hoặc mật khẩu không hợp lê", "Đồng ý");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", ex.Message, "Đồng ý");

            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}

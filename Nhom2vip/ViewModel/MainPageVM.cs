
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Nhom2vip.Model;
using Nhom2vip.View;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Nhom2vip.ViewModel
{
    public class MainPageVM : BaseVM
    {
        public MainPageVM(INavigation navigation)
        {

            Navigation = navigation;
            GetCategores();
            GetItems();
            GetToyItems();
            SelectGroupCommand = new Command<CategoryModel>((model) => ExecuteSelectGroupCommand(model));
            NavigateToDetailPageCommand = new Command<ItemModel>(async (model) => await ExecuteNavigateToDetailPageCommand(model));

        }

        public Command NavigateToDetailPageCommand { get; }
        public Command SelectGroupCommand { get; }
        private ObservableCollection<ItemModel> itemModelList;
        public ObservableCollection<ItemModel> ItemModelList
        {
            get => itemModelList;
            set
            {
                itemModelList = value;
                OnPropertyChanged(nameof(ItemModelList));

            }
        }
        private ObservableCollection<ItemModel> itemToyModelList;
        public ObservableCollection<ItemModel> ItemToyModelList
        {
            get => itemToyModelList;
            set
            {
                itemToyModelList = value;
                OnPropertyChanged(nameof(ItemToyModelList));
            }
        }
        private ObservableCollection<CategoryModel> categoryModelList;
        public ObservableCollection<CategoryModel> CategoryModelList
        {
            get => categoryModelList;
            set
            {
                categoryModelList = value;
                OnPropertyChanged(nameof(CategoryModelList));
            }
        }
        public void GetCategores()
        {
            categoryModelList = new ObservableCollection<CategoryModel>();
            categoryModelList.Add(new CategoryModel { Name = "All Product", Select = true });
            categoryModelList.Add(new CategoryModel { Name = "Sneakers", Select = false });
            categoryModelList.Add(new CategoryModel { Name = "Accessories", Select = false });
            categoryModelList.Add(new CategoryModel { Name = "Collection", Select = false });
        }
        public void GetItems()
        {
            itemModelList = new ObservableCollection<ItemModel>();
            itemModelList.Add(new ItemModel { Name = "Nike Air Jordan 1 Bred Toe ", Image = "1.jpeg" , ItemType = Enum.ItemType.Other,Price = "$150"});
            itemModelList.Add(new ItemModel { Name = "Nike Air Jordan 1 Retro High Dior", Image = "2.jpeg" ,ItemType = Enum.ItemType.Other, Price = "$250"  });
            itemModelList.Add(new ItemModel { Name = "Nike Air Jordan 1 Retro High Black White", Image= "3.jpeg", ItemType = Enum.ItemType.Toy, Price = "$220" });
            itemModelList.Add(new ItemModel { Name = "Nike air Jordan 1 Black Toe Low", Image= "4.jpeg", ItemType = Enum.ItemType.Toy, Price = "$150" });
            itemModelList.Add(new ItemModel { Name = "Air Jordan 1 Retro High OG", Image = "6.jpeg", ItemType = Enum.ItemType.Toy, Price = "$600" });
            itemModelList.Add(new ItemModel { Name = "Jordan 1 Retro High University Blue", Image = "7.jpeg", ItemType = Enum.ItemType.Toy, Price = "$600" });
            itemModelList.Add(new ItemModel { Name = "Air Jordan 1 Retro High OG“Gym Red”", Image = "8.jpeg", ItemType = Enum.ItemType.Toy, Price = "$600" });

        }
        public void GetToyItems()
        {
            itemToyModelList = new ObservableCollection<ItemModel>(itemModelList.Where(x => x.ItemType == Enum.ItemType.Toy).ToList());
        }
        private void ExecuteSelectGroupCommand(CategoryModel model)
        {
            CategoryModelList.ForEach((item) =>
            {
                if(item == model)
                item.Select = true;
                else item.Select = false;
            });
             OnPropertyChanged(nameof(CategoryModelList));
        }
        private async Task ExecuteNavigateToDetailPageCommand(ItemModel model)
        {
            await Navigation.PushAsync(new DetailPage(model));
        }
    }
}

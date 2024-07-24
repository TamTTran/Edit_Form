using Edit_Info.Command;
using Edit_Info.Model;
using Edit_Info.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Edit_Info.ViewMoel
{
     
    public class FarmVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private  string connectionString = "Data Source=TRAN_THANH_TAM;Initial Catalog=db_test;Integrated Security=True";

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<FarmModel> farm_model;

        #region checkbox

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged(nameof(IsChecked)); Task.Run(async () => await CheckAllIsCheckedAsync(value)); }
        }

        private async Task CheckAllIsCheckedAsync(bool value)
        {
            try
            {
                if (entityListMenu != null)
                {
                    await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                    {
                        entityListMenu = new ObservableCollection<FarmModel>(_entityListMenu.Select(c => { c.IsCheck = value; return c; }));
                    }));
                }
            }
            catch (Exception e)
            {
            }
        }

        #endregion checkbox

        #region gridselected

        private FarmModel _UserSelected;

        public FarmModel UserSelected
        {
            get => _UserSelected;
            set
            {
            }
        }

        #endregion gridselected

        #region constructor

        public FarmVM()
        {
            FillData();
        }

        #endregion constructor

        #region Enitity

        private ObservableCollection<FarmModel> _FarmSource;

        public ObservableCollection<FarmModel> FarmSource
        {
            get => _FarmSource;
            set
            {
                _FarmSource = value;
                OnPropertyChanged("FarmSource");
            }
        }

        public ObservableCollection<FarmModel> _entityListMenu;

        public ObservableCollection<FarmModel> entityListMenu
        {
            get => _entityListMenu;
            set
            {
                _entityListMenu = value;
                OnPropertyChanged("entityListMenu");
            }
        }

        #endregion Enitity

        #region TextBox

        public string _txtLocationID;
        public string txtLocationID
        {
            get => _txtLocationID;
            set
            {
                _txtLocationID = value;
                OnPropertyChanged("ID");
            }
        }

        public string _txtLocationName;

        public string txtLocationName
        {
            get => _txtLocationName;
            set
            {
                txtLocationName = value;
                OnPropertyChanged("locationName");
            }
        }

        public string _txtLocationAddress;

        public string txtLocationAddress
        {
            get => txtLocationAddress;
            set
            {
                txtLocationAddress = value;
                OnPropertyChanged("locationAddress");
            }
        }

        public string _txtNameENIV;

        public string txtNameENIV
        {
            get => _txtNameENIV;
            set
            {
                txtNameENIV = value;
                OnPropertyChanged("nameENIV");
            }
        }

        public string _txtAddressENIV;

        public string txtAddressENIV
        {
            get => _txtAddressENIV;
            set
            {
                txtAddressENIV = value;
                OnPropertyChanged("addressENIV");
            }
        }

        #endregion TextBox

        #region command

        private ICommand _Savecommand;

        public ICommand SaveCommand
        {
            get
            {
                return _Savecommand ?? (_Savecommand = new RelayCommand<object>(obj =>
                {
                    Save();
                }));
            }
        }

        #endregion command

        #region function

        public void Save()
        {
        }

        public void FillData()
        {
            FarmRepository farmRepository = new FarmRepository(connectionString);
            var model = farmRepository.GetAllFarmModels();
             FarmSource = new ObservableCollection<FarmModel>();
            foreach (var item in model)
            {
                FarmModel farmModel = new FarmModel();
                farmModel.LocationID = item.LocationID;
                farmModel.LocationName = item.LocationName;
                farmModel.AddressEINV = item.AddressEINV;
                farmModel.NameEINV = item.NameEINV;
                farmModel.Tax = item.Tax;

                FarmSource.Add(farmModel);

            }
        }

        #endregion function
    }
}
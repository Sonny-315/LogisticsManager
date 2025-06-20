using LogisticsManager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace LogisticsManager.ViewModel
{
    public class LogisBox : ViewModelBase
    {
        #region COMMAND
        // InitLogisView
        private ICommand _CmdLogisGridSave;
        private ICommand _CmdLogisGridCancel;

        public ICommand CmdLogisGridSave { get { return (_CmdLogisGridSave) ?? (_CmdLogisGridSave = new DelegateCommand(LogisGridSave)); } }
        public ICommand CmdLogisGridCancel { get { return (_CmdLogisGridCancel) ?? (_CmdLogisGridCancel = new DelegateCommand(LogisGridCancel)); } }
        #endregion


        string _strTitle;
        public string m_strTitle { get { return _strTitle; } set { _strTitle = value; OnPropertyChanged("m_strTitle"); } }

        int _nSetRow;
        public int m_nSetRow { get { return _nSetRow; } set { _nSetRow = value; OnPropertyChanged("m_nSetRow"); } }

        int _nSetCol;
        public int m_nSetCol { get { return _nSetCol; } set { _nSetCol = value; OnPropertyChanged("m_nSetCol"); } }


        MainViewModel mvm;


        public LogisBox(MainViewModel _mvm)
        {
            mvm = _mvm;
        }


        void LogisGridSave(object obj)
        {
            if (m_nSetRow <= 0)
            {
                MessageBox.Show("Row 값이 설정되지 않았습니다.");
                return;
            }

            if (m_nSetCol <= 0)
            {
                MessageBox.Show("Col 값이 설정되지 않았습니다.");
                return;
            }


            if (m_nSetRow > 0 && m_nSetCol > 0)
            {
                mvm.mv.InitSettingGrid.Visibility = System.Windows.Visibility.Collapsed;                // InitSettingGrid Collapsed
                mvm.mv.LogisStatusGrid.Visibility = System.Windows.Visibility.Visible;                  // LogisStatusGrid Visible

                //for (int i = 0; i < m_nSelInitRow; i++)
                //{
                //    mv.LogisStatusGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
                //}

                //for (int i = 0; i < m_nSelInitCol; i++)
                //{
                //    mv.LogisStatusGrid.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition());
                //}


                //for (int i = 0; i < m_nSelInitRow; i++)
                //{
                //    for (int j = 0; j < m_nSelInitCol; j++)
                //    {
                //        //ToggleButton tgButton = new ToggleButton
                //        //{
                //        //    Content = string.Format($"{j+1}");
                //        //};


                //    }
                //}




                Console.WriteLine("LogisGrid Save!");
            }
            else
            {

            }


        }

        void LogisGridCancel(object obj)
        {
            Console.WriteLine("LogisGrid Cancel!");

            mvm.initView.Close();
        }


    }

    public class MainViewModel : ViewModelBase
    {

        #region COMMAND
        private ICommand _CmdInitSetting;

        public ICommand CmdInitSetting { get { return (_CmdInitSetting) ?? (_CmdInitSetting = new DelegateCommand(InitLogisticsGrid)); } }


     


        #endregion


        #region Property

        public List<int> lstInitRow { get; set; }
        public List<int> lstInitCol { get; set; }


        int _nSelInitRow;
        int _nSelInitCol;

        public int m_nSelInitRow { get { return _nSelInitRow; } set { _nSelInitRow = value; OnPropertyChanged("m_nSelInitRow"); } }
        public int m_nSelInitCol { get { return _nSelInitCol; } set { _nSelInitCol = value; OnPropertyChanged("m_nSelInitCol"); } }


        #endregion


        public MainView mv;
        public InitLogisView initView;


        ObservableCollection<LogisBox> logisCollection;




        public MainViewModel(MainView _mv)
        {
            mv = _mv;

            logisCollection = new ObservableCollection<LogisBox>();

            lstInitRow = new List<int>();
            lstInitCol = new List<int>(); 
            for (int i = 0; i < 10; i++)
            {
                lstInitRow.Add(i + 1);
                lstInitCol.Add(i + 1);
            }



            // db 에서 LogisGrid Setting 값이 없으면 InitSettingGrid 로딩
            // LogisGrid Setting 값이 있으면 해당 Row, Column으로 로딩



        }


        void InitLogisticsGrid(object obj)
        {
            initView = new InitLogisView();

            LogisBox box = new LogisBox(this);
            initView.DataContext = box;

            if (initView.ShowDialog() == false)
            {
                Console.WriteLine("Close InitLogisView!");

            }

        }



        



    }
}

using LogisticsManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LogisticsManager
{
    public class MainViewModel
    {

        #region COMMAND
        private ICommand _CmdInitSetting;

        public ICommand CmdInitSetting { get { return (_CmdInitSetting) ?? (_CmdInitSetting = new DelegateCommand(InitLogisticsGrid)); } }


        // InitLogisView
        private ICommand _CmdLogisGridSave;
        private ICommand _CmdLogisGridCancel;

        public ICommand CmdLogisGridSave { get { return (_CmdLogisGridSave) ?? (_CmdLogisGridSave = new DelegateCommand(LogisGridSave)); } }
        public ICommand CmdLogisGridCancel { get { return (_CmdLogisGridCancel) ?? (_CmdLogisGridCancel = new DelegateCommand(LogisGridCancel)); } }


        #endregion


        MainView mv;
        InitLogisView initView;




        public MainViewModel(MainView _mv)
        {
            mv = _mv;


            // db 에서 LogisGrid Setting 값이 없으면 InitSettingGrid 로딩
            // LogisGrid Setting 값이 있으면 해당 Row, Column으로 로딩



        }


        void InitLogisticsGrid(object obj)
        {
            initView = new InitLogisView();
            initView.DataContext = this;

            if (initView.ShowDialog() == false)
            {
                Console.WriteLine("Close InitLogisView!");

            }

        }



        void LogisGridSave(object obj)
        {
            Console.WriteLine("LogisGrid Save!");
        }

        void LogisGridCancel(object obj)
        {
            Console.WriteLine("LogisGrid Cancel!");

            initView.Close();
        }



    }
}

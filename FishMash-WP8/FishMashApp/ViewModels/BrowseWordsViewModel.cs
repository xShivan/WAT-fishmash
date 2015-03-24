﻿using FishMashApp.Common;
using FishMashApp.Models;
using FishMashApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FishMashApp.WebAPI;

namespace FishMashApp.ViewModels
{
    class BrowseWordsViewModel : BaseViewModel
    {
    #region Properties
        #region Binding
        public ObservableCollection<ListOfLists> ListOfList
        {
            get;
            set;
        }
        
        #endregion

        public ICommand Click
        {
            get
            {
                return null ??
                    new RelayCommand(o =>
                    {
                        this.navigationService.Naviagte(typeof(WordView));
                    });
            }
        }
    #endregion

        public BrowseWordsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ListOfList = new ObservableCollection<ListOfLists>();
            FillList(); //only for temp
        }

        public async void FillList()
        {
            List<ListOfLists> x = await WebService.GetListOfListAsync();
            OnUIThread(() =>
            {
                foreach (ListOfLists t in x)
                {
                    ListOfList.Add(t);
                }
            });
        }

        public void goToNextPage()
        {
            this.navigationService.Naviagte(typeof(WordView));
        }
    }
}

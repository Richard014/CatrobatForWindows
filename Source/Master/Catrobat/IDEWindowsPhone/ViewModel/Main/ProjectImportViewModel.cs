﻿using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Catrobat.IDEWindowsPhone.Misc;
using Catrobat.IDEWindowsPhone.Views.Main;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Catrobat.IDEWindowsPhone.ViewModel.Main
{
    public class ProjectImportViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region private Members

        private ProjectImporter _importer;
        private bool _isWorking = false;

        private bool _contentPanelVisibility = false;
        private bool _loadingPanelVisibility = true;
        private bool _progressBarLoadingIsIndeterminate = true;
        private bool _checkBoxMakeActiveIsChecked = true;
        private bool _buttonAddIsEnabled = true;
        private bool _buttonCancelIsEnabled = true;
        private string _projectName = "";
        private ImageSource _screenshotImageSource = null;

        #endregion

        #region Properties

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value == _projectName)
                {
                    return;
                }
                _projectName = value;
                RaisePropertyChanged("ProjectName");
            }
        }

        public ImageSource ScreenshotImageSource
        {
            get { return _screenshotImageSource; }
            set
            {
                if (_screenshotImageSource == value)
                {
                    return;
                }
                _screenshotImageSource = value;
                RaisePropertyChanged("ScreenshotImageSource");
            }
        }

        public bool ContentPanelVisibility
        {
            get { return _contentPanelVisibility; }
            set
            {
                if (value == _contentPanelVisibility)
                {
                    return;
                }
                _contentPanelVisibility = value;
                RaisePropertyChanged("ContentPanelVisibility");
            }
        }

        public bool LoadingPanelVisibility
        {
            get { return _loadingPanelVisibility; }
            set
            {
                if (value == _loadingPanelVisibility)
                {
                    return;
                }
                _loadingPanelVisibility = value;
                RaisePropertyChanged("LoadingPanelVisibility");
            }
        }

        public bool ProgressBarLoadingIsIndeterminate
        {
            get { return _progressBarLoadingIsIndeterminate; }
            set
            {
                if (value == _progressBarLoadingIsIndeterminate)
                {
                    return;
                }
                _progressBarLoadingIsIndeterminate = value;
                RaisePropertyChanged("ProgressBarLoadingIsIndeterminate");
            }
        }

        public bool CheckBoxMakeActiveIsChecked
        {
            get { return _checkBoxMakeActiveIsChecked; }
            set
            {
                if (value == _checkBoxMakeActiveIsChecked)
                {
                    return;
                }
                _checkBoxMakeActiveIsChecked = value;
                RaisePropertyChanged("CheckBoxMakeActiveIsChecked");
            }
        }

        public bool ButtonAddIsEnabled
        {
            get { return _buttonAddIsEnabled; }
            set
            {
                if (value == _buttonAddIsEnabled)
                {
                    return;
                }
                _buttonAddIsEnabled = value;
                RaisePropertyChanged("ButtonAddIsEnabled");
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public bool ButtonCancelIsEnabled
        {
            get { return _buttonCancelIsEnabled; }
            set
            {
                if (value == _buttonCancelIsEnabled)
                {
                    return;
                }
                _buttonCancelIsEnabled = value;
                RaisePropertyChanged("ButtonCancelIsEnabled");
                CancelCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand AddCommand { get; private set; }

        public RelayCommand CancelCommand { get; private set; }

        public ICommand OnLoadCommand { get; private set; }

        public RelayCommand ResetViewModelCommand { get; private set; }

        #endregion

        #region CommandCanExecute

        private bool AddCommand_CanExecute()
        {
            return ButtonAddIsEnabled;
        }

        private bool CancelCommand_CanExecute()
        {
            return ButtonCancelIsEnabled;
        }

        #endregion

        #region Actions

        private void AddAction()
        {
            if (_isWorking)
            {
                return;
            }

            _isWorking = true;

            ButtonAddIsEnabled = false;
            ButtonCancelIsEnabled = false;
            ContentPanelVisibility = false;
            LoadingPanelVisibility = true;
            ProgressBarLoadingIsIndeterminate = true;

            var task = Task.Run(() =>
                {
                    try
                    {
                        if (_importer != null)
                        {
                            _importer.AcceptTempProject(CheckBoxMakeActiveIsChecked);
                        }

                        Deployment.Current.Dispatcher.BeginInvoke(() => { Navigation.NavigateTo(typeof (MainView)); });
                    }
                    catch
                    {
                        ShowErrorMessage();
                    }
                });

            _isWorking = false;
        }

        private void CancelAction()
        {
            Navigation.NavigateTo(typeof (MainView));
        }

        private async void OnLoadAction(NavigationContext navigationContext)
        {
            _isWorking = true;
            var fileToken = string.Empty;
            if (navigationContext.QueryString.TryGetValue("fileToken", out fileToken))
            {
                _importer = new ProjectImporter();
                var projectHeader = await _importer.ImportProjects(fileToken);

                if (projectHeader != null)
                {
                    ProjectName = projectHeader.ProjectName;

                    ScreenshotImageSource = projectHeader.Screenshot as BitmapImage;
                    ContentPanelVisibility = true;
                    LoadingPanelVisibility = false;
                    ProgressBarLoadingIsIndeterminate = false;
                }
                else
                {
                    ShowErrorMessage();
                }
            }
            _isWorking = false;
        }

        private void ResetViewModelAction()
        {
            ResetViewModel();
        }

        #endregion

        public ProjectImportViewModel()
        {
            // Commands
            AddCommand = new RelayCommand(AddAction, AddCommand_CanExecute);
            CancelCommand = new RelayCommand(CancelAction, CancelCommand_CanExecute);
            OnLoadCommand = new RelayCommand<NavigationContext>(OnLoadAction);
            ResetViewModelCommand = new RelayCommand(ResetViewModelAction);
        }

        private void ShowErrorMessage()
        {
            var message = new DialogMessage("Sorry! The project is not valid or not compatible with this version of Catrobat.", ProjectNotValidMessageResult)
            {
                Button = MessageBoxButton.OK,
                Caption = "Project can not be opened"
            };
            Messenger.Default.Send(message);
        }

        private void ProjectNotValidMessageResult(MessageBoxResult obj)
        {
            Navigation.NavigateTo(typeof (MainView));
        }

        private void ResetViewModel()
        {
            ProjectName = "";
            ContentPanelVisibility = false;
            LoadingPanelVisibility = true;
            ProgressBarLoadingIsIndeterminate = true;
            CheckBoxMakeActiveIsChecked = true;
            ButtonAddIsEnabled = true;
            ButtonCancelIsEnabled = true;
            ProjectName = "";
            ScreenshotImageSource = null;
        }
    }
}
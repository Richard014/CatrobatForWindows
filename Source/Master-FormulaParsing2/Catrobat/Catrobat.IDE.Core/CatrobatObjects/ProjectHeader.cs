﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Catrobat.IDE.Core.Services.Storage;
using Catrobat.IDE.Core.Utilities.Helpers;
using Catrobat.IDE.Core.Services;

namespace Catrobat.IDE.Core.CatrobatObjects
{
    public class ProjectHeader : DataObject
    {
        private string _applicationBuildName;

        public string ApplicationBuildName
        {
            get { return _applicationBuildName; }
            set
            {
                if (_applicationBuildName == value)
                    return;

                _applicationBuildName = value;
                RaisePropertyChanged();
            }
        }

        private int _applicationBuildNumber;

        public int ApplicationBuildNumber
        {
            get { return _applicationBuildNumber; }
            set
            {
                if (_applicationBuildNumber == value)
                    return;

                _applicationBuildNumber = value;
                RaisePropertyChanged();
            }
        }

        private string _applicationName;

        public string ApplicationName
        {
            get { return _applicationName; }
            set
            {
                if (_applicationName == value)
                    return;

                _applicationName = value;
                RaisePropertyChanged();
            }
        }

        private string _applicationVersion;

        public string ApplicationVersion
        {
            get { return _applicationVersion; }
            set
            {
                if (_applicationVersion == value)
                    return;

                _applicationVersion = value;
                RaisePropertyChanged();
            }
        }

        private string _catrobatLanguageVersion;

        public string CatrobatLanguageVersion
        {
            get { return _catrobatLanguageVersion; }
            set
            {
                if (_catrobatLanguageVersion == value)
                    return;

                _catrobatLanguageVersion = value;
                RaisePropertyChanged();
            }
        }

        private string _dateTimeUpload;

        public string DateTimeUpload
        {
            get { return _dateTimeUpload; }
            set
            {
                if (_dateTimeUpload == value)
                    return;

                _dateTimeUpload = value;
                RaisePropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;

                _description = value;
                RaisePropertyChanged();
            }
        }

        private string _deviceName;

        public string DeviceName
        {
            get { return _deviceName; }
            set
            {
                if (_deviceName == value)
                    return;

                _deviceName = value;
                RaisePropertyChanged();
            }
        }

        private string _mediaLicense;

        public string MediaLicense
        {
            get { return _mediaLicense; }
            set
            {
                if (_mediaLicense == value)
                    return;

                _mediaLicense = value;
                RaisePropertyChanged();
            }
        }

        private string _platform;

        public string Platform
        {
            get { return _platform; }
            set
            {
                if (_platform == value)
                    return;

                _platform = value;
                RaisePropertyChanged();
            }
        }

        private string _platformVersion;

        public string PlatformVersion
        {
            get { return _platformVersion; }
            set
            {
                if (_platformVersion == value)
                    return;

                _platformVersion = value;
                RaisePropertyChanged();
            }
        }

        private string _programLicense;

        public string ProgramLicense
        {
            get { return _programLicense; }
            set
            {
                if (_programLicense == value)
                    return;

                _programLicense = value;
                RaisePropertyChanged();
            }
        }

        private string _programName;
        public string ProgramName
        {
            get { return _programName; }
            set
            {
                if (_programName == value)
                    return;

                _programName = value;
                RaisePropertyChanged();
            }
        }

        private string _remixOf;
        public string RemixOf
        {
            get { return _remixOf; }
            set
            {
                if (_remixOf == value)
                    return;

                _remixOf = value;
                RaisePropertyChanged();
            }
        }

        private int _screenHeight;
        public int ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                if (_screenHeight == value)
                    return;

                _screenHeight = value;
                RaisePropertyChanged();
            }
        }

        private int _screenWidth;
        public int ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                if (_screenWidth == value)
                    return;

                _screenWidth = value;
                RaisePropertyChanged();
            }
        }

        private string _tags;
        public string Tags
        {
            get { return _tags; }
            set
            {
                if (_tags == value)
                    return;

                _tags = value;
                RaisePropertyChanged();
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                if (_url == value)
                    return;

                _url = value;
                RaisePropertyChanged();
            }
        }

        private string _userHandle;
        public string UserHandle
        {
            get { return _userHandle; }
            set
            {
                if (_userHandle == value)
                    return;

                _userHandle = value;
                RaisePropertyChanged();
            }
        }

        public ProjectHeader(bool isAutoFillProperties = true)
        {
            if (isAutoFillProperties)
            {
                AutoFill();
                UpdateSystemInformation();
            }
        }

        private void AutoFill()
        {
            DateTimeUpload = "";
            Description = "";
            MediaLicense = "http://developer.catrobat.org/ccbysa_v3";
            ProgramLicense = "http://developer.catrobat.org/agpl_v3";
            _programName = ""; //otherwise renameDirectory would be executed
            RemixOf = "";
            Tags = "";
            Url = "http://pocketcode.org/details/871";
            UserHandle = "";
        }

        private void UpdateSystemInformation()
        {
            ApplicationBuildName = Constants.CurrentAppBuildName;
            ApplicationBuildNumber = Constants.CurrentAppBuildNumber;
            ApplicationName = Constants.ApplicationName;
            ApplicationVersion = Constants.CurrentAppVersion;
            CatrobatLanguageVersion = Constants.TargetIDEVersion;
            DeviceName = ServiceLocator.SystemInformationService.DeviceName;
            Platform = ServiceLocator.SystemInformationService.PlatformName;
            PlatformVersion = ServiceLocator.SystemInformationService.PlatformVersion;
            ScreenHeight = ServiceLocator.SystemInformationService.ScreenHeight;
            ScreenWidth = ServiceLocator.SystemInformationService.ScreenWidth;
        }

        public ProjectHeader(XElement xElement)
        {
            LoadFromXML(xElement);
        }

        internal override void LoadFromXML(XElement xRoot)
        {
            _applicationBuildName = xRoot.Element("applicationBuildName").Value;
            _applicationBuildNumber = int.Parse(xRoot.Element("applicationBuildNumber").Value, CultureInfo.InvariantCulture);
            _applicationName = xRoot.Element("applicationName").Value;
            _applicationVersion = xRoot.Element("applicationVersion").Value;
            _catrobatLanguageVersion = xRoot.Element("catrobatLanguageVersion").Value;
            _dateTimeUpload = xRoot.Element("dateTimeUpload").Value;
            _description = xRoot.Element("description").Value;
            _deviceName = xRoot.Element("deviceName").Value;
            _mediaLicense = xRoot.Element("mediaLicense").Value;
            _platform = xRoot.Element("platform").Value;
            _platformVersion = xRoot.Element("platformVersion").Value;
            _programLicense = xRoot.Element("programLicense").Value;
            _programName = xRoot.Element("programName").Value;
            _remixOf = xRoot.Element("remixOf").Value;
            _screenHeight = int.Parse(xRoot.Element("screenHeight").Value, CultureInfo.InvariantCulture);
            _screenWidth = int.Parse(xRoot.Element("screenWidth").Value, CultureInfo.InvariantCulture);
            _tags = xRoot.Element("tags").Value;
            _url = xRoot.Element("url").Value;
            _userHandle = xRoot.Element("userHandle").Value;
        }

        internal override XElement CreateXML()
        {
            UpdateSystemInformation();

            var xProjectHeader = new XElement("header");

            xProjectHeader.Add(new XElement("applicationBuildName")
                {
                    Value = _applicationBuildName
                });

            xProjectHeader.Add(new XElement("applicationBuildNumber")
                {
                    Value = _applicationBuildNumber.ToString(CultureInfo.InvariantCulture)
                });

            xProjectHeader.Add(new XElement("applicationName")
                {
                    Value = _applicationName
                });

            xProjectHeader.Add(new XElement("applicationVersion")
                {
                    Value = _applicationVersion
                });

            xProjectHeader.Add(new XElement("catrobatLanguageVersion")
                {
                    Value = _catrobatLanguageVersion
                });

            xProjectHeader.Add(new XElement("dateTimeUpload")
                {
                    Value = _dateTimeUpload
                });

            xProjectHeader.Add(new XElement("description")
                {
                    Value = _description
                });

            xProjectHeader.Add(new XElement("deviceName")
                {
                    Value = _deviceName
                });

            xProjectHeader.Add(new XElement("mediaLicense")
                {
                    Value = _mediaLicense
                });

            xProjectHeader.Add(new XElement("platform")
                {
                    Value = _platform
                });

            xProjectHeader.Add(new XElement("platformVersion")
                {
                    Value = _platformVersion
                });

            xProjectHeader.Add(new XElement("programLicense")
                {
                    Value = _programLicense
                });

            xProjectHeader.Add(new XElement("programName")
                {
                    Value = _programName
                });

            xProjectHeader.Add(new XElement("remixOf")
                {
                    Value = _remixOf
                });

            xProjectHeader.Add(new XElement("screenHeight")
                {
                    Value = _screenHeight.ToString(CultureInfo.InvariantCulture)
                });

            xProjectHeader.Add(new XElement("screenWidth")
                {
                    Value = _screenWidth.ToString(CultureInfo.InvariantCulture)
                });

            xProjectHeader.Add(new XElement("tags")
                {
                    Value = _tags
                });

            xProjectHeader.Add(new XElement("url")
                {
                    Value = _url
                });

            xProjectHeader.Add(new XElement("userHandle")
                {
                    Value = _userHandle
                });

            return xProjectHeader;
        }

        public void SetProgramName(string newProgramName)
        {
            _programName = newProgramName;
            RaisePropertyChanged(() => ProgramName);
        }

        public override bool Equals(DataObject other)
        {
            var otherProjectHeader = other as ProjectHeader;

            if (otherProjectHeader == null)
                return false;

            if (ApplicationBuildName != otherProjectHeader.ApplicationBuildName)
                return false;
            if (ApplicationBuildNumber != otherProjectHeader.ApplicationBuildNumber)
                return false;
            if (ApplicationName != otherProjectHeader.ApplicationName)
                return false;
            if (ApplicationVersion != otherProjectHeader.ApplicationVersion)
                return false;
            if (CatrobatLanguageVersion != otherProjectHeader.CatrobatLanguageVersion)
                return false;
            if (DateTimeUpload != otherProjectHeader.DateTimeUpload)
                return false;
            if (Description != otherProjectHeader.Description)
                return false;
            if (DeviceName != otherProjectHeader.DeviceName)
                return false;
            if (MediaLicense != otherProjectHeader.MediaLicense)
                return false;
            if (Platform != otherProjectHeader.Platform)
                return false;
            if (PlatformVersion != otherProjectHeader.PlatformVersion)
                return false;
            if (ProgramLicense != otherProjectHeader.ProgramLicense)
                return false;
            if (ProgramName != otherProjectHeader.ProgramName)
                return false;
            if (RemixOf != otherProjectHeader.RemixOf)
                return false;
            if(ScreenHeight != otherProjectHeader.ScreenHeight)
                return false;
            if (ScreenWidth != otherProjectHeader.ScreenWidth)
                return false;
            if (Tags != otherProjectHeader.Tags)
                return false;
            if (Url != otherProjectHeader.Url)
                return false;
            if (UserHandle != otherProjectHeader.UserHandle)
                return false;

            return true;
        }
    }
}
#pragma once

#include "BaseObject.h"
#include "ObjectList.h"
#include "UserVariable.h"

#include <vector>

class Project
{
public:
	Project(
	std::string							applicationBuildName,
	int									applicationBuildNumber,
	std::string							applicationName,
	std::string							applicationVersion,
	std::string							catrobatLanguageVersion,
	time_t								dateTimeUpload,
	std::string							description,
	std::string							deviceName,
	std::string							mediaLicense,
	std::string							platform,
	int									platformVersion,
	std::string							programLicense,
	std::string							programName,
	std::string							remixOf,
	int									screenHeight,
	int									screenWidth,
	std::vector<std::string>*			tags,
	std::string							url,
	std::string							userHandle
	);

	~Project();

	void								Render			(SpriteBatch *spriteBatch);
	void								LoadTextures	(ID3D11Device* d3dDevice);
	void								StartUp();

	// Getters for Project Header
	int									ScreenHeight();
	int									ScreenWidth();

	ObjectList*							getObjectList();
	UserVariable*						Variable(std::string name);
	void								addVariable(std::string name, UserVariable *variable);
	void								addVariable(std::pair<string, UserVariable*> variable);


private:

	// Project Header
	std::string							m_applicationBuildName;
	int									m_applicationBuildNumber;
	std::string							m_applicationName;
	std::string							m_applicationVersion;
	std::string							m_catrobatLanguageVersion;
	time_t								m_dateTimeUpload;
	std::string							m_description;
	std::string							m_deviceName;
	std::string							m_mediaLicense;
	std::string							m_platform;
	int									m_platformVersion;
	std::string							m_programLicense;
	std::string							m_programName;
	std::string							m_remixOf;
	int									m_screenHeight;
	int									m_screenWidth;
	std::vector<std::string>*			m_tags;
	std::string							m_url;
	std::string							m_userHandle;

	ObjectList*							m_objectList;
	std::map<std::string, UserVariable*>*	m_variableList;
};

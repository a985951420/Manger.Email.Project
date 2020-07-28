; 该脚本使用 HM VNISEdit 脚本编辑器向导产生

; 安装程序初始定义常量
!define PRODUCT_NAME "邮件管理助手"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "Time"
!define PRODUCT_WEB_SITE "http://www.ntail.cn"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\Email.Windows.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI 现代界面定义 (1.67 版本以上兼容) ------
!include "MUI.nsh"

; MUI 预定义常量
!define MUI_ABORTWARNING
!define MUI_ICON "..\windows.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; 欢迎页面
!insertmacro MUI_PAGE_WELCOME
; 许可协议页面
!insertmacro MUI_PAGE_LICENSE "..\Licence.txt"
; 安装目录选择页面
!insertmacro MUI_PAGE_DIRECTORY
; 安装过程页面
!insertmacro MUI_PAGE_INSTFILES
; 安装完成页面
!insertmacro MUI_PAGE_FINISH

; 安装卸载过程页面
!insertmacro MUI_UNPAGE_INSTFILES

; 安装界面包含的语言设置
!insertmacro MUI_LANGUAGE "SimpChinese"

; 安装预释放文件
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI 现代界面定义结束 ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "邮件管理助手安装包.exe"
InstallDir "$PROGRAMFILES\MailManagementAssistant"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR\MailManagementAssistant"
  SetOverwrite ifnewer
  File /r "..\bin\Release\*.*"
  CreateDirectory "$SMPROGRAMS\邮件管理助手"
  CreateShortCut "$SMPROGRAMS\邮件管理助手\邮件管理助手.lnk" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  CreateShortCut "$DESKTOP\邮件管理助手.lnk" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  File "..\bin\Release\System.Data.SQLite.xml"
  File "..\bin\Release\System.Data.SQLite.Linq.dll"
  File "..\bin\Release\System.Data.SQLite.EF6.dll"
  File "..\bin\Release\System.Data.SQLite.dll.config"
  File "..\bin\Release\System.Data.SQLite.dll"
  File "..\bin\Release\System.Collections.Immutable.xml"
  File "..\bin\Release\System.Collections.Immutable.dll"
  File "..\bin\Release\MimeKit.xml"
  File "..\bin\Release\MimeKit.pdb"
  File "..\bin\Release\MimeKit.dll"
  File "..\bin\Release\MailKit.xml"
  File "..\bin\Release\MailKit.pdb"
  File "..\bin\Release\MailKit.dll"
  File "..\bin\Release\Krypton.Toolkit.xml"
  File "..\bin\Release\Krypton.Toolkit.dll"
  File "..\bin\Release\EntityFramework.xml"
  File "..\bin\Release\EntityFramework.SqlServer.xml"
  File "..\bin\Release\EntityFramework.SqlServer.dll"
  File "..\bin\Release\EntityFramework.dll"
  File "..\bin\Release\Email.Windows.exe.config"
  File "..\bin\Release\Email.Windows.exe"
  File "..\bin\Release\BouncyCastle.Crypto.xml"
  File "..\bin\Release\BouncyCastle.Crypto.dll"
SectionEnd

Section -AdditionalIcons
  SetOutPath $INSTDIR
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\邮件管理助手\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\邮件管理助手\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

/******************************
 *  以下是安装程序的卸载部分  *
 ******************************/

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\MailManagementAssistant\BouncyCastle.Crypto.dll"
  Delete "$INSTDIR\MailManagementAssistant\BouncyCastle.Crypto.xml"
  Delete "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  Delete "$INSTDIR\MailManagementAssistant\Email.Windows.exe.config"
  Delete "$INSTDIR\MailManagementAssistant\EntityFramework.dll"
  Delete "$INSTDIR\MailManagementAssistant\EntityFramework.SqlServer.dll"
  Delete "$INSTDIR\MailManagementAssistant\EntityFramework.SqlServer.xml"
  Delete "$INSTDIR\MailManagementAssistant\EntityFramework.xml"
  Delete "$INSTDIR\MailManagementAssistant\Krypton.Toolkit.dll"
  Delete "$INSTDIR\MailManagementAssistant\Krypton.Toolkit.xml"
  Delete "$INSTDIR\MailManagementAssistant\MailKit.dll"
  Delete "$INSTDIR\MailManagementAssistant\MailKit.pdb"
  Delete "$INSTDIR\MailManagementAssistant\MailKit.xml"
  Delete "$INSTDIR\MailManagementAssistant\MimeKit.dll"
  Delete "$INSTDIR\MailManagementAssistant\MimeKit.pdb"
  Delete "$INSTDIR\MailManagementAssistant\MimeKit.xml"
  Delete "$INSTDIR\MailManagementAssistant\System.Collections.Immutable.dll"
  Delete "$INSTDIR\MailManagementAssistant\System.Collections.Immutable.xml"
  Delete "$INSTDIR\MailManagementAssistant\System.Data.SQLite.dll"
  Delete "$INSTDIR\MailManagementAssistant\System.Data.SQLite.dll.config"
  Delete "$INSTDIR\MailManagementAssistant\System.Data.SQLite.EF6.dll"
  Delete "$INSTDIR\MailManagementAssistant\System.Data.SQLite.Linq.dll"
  Delete "$INSTDIR\MailManagementAssistant\System.Data.SQLite.xml"

  Delete "$SMPROGRAMS\邮件管理助手\Uninstall.lnk"
  Delete "$SMPROGRAMS\邮件管理助手\Website.lnk"
  Delete "$DESKTOP\邮件管理助手.lnk"
  Delete "$SMPROGRAMS\邮件管理助手\邮件管理助手.lnk"

  RMDir "$SMPROGRAMS\邮件管理助手"
  RMDir "$INSTDIR\MailManagementAssistant"

  RMDir /r "$INSTDIR\MailManagementAssistant"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd

#-- 根据 NSIS 脚本编辑规则，所有 Function 区段必须放置在 Section 区段之后编写，以避免安装程序出现未可预知的问题。--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "您确实要完全移除 $(^Name) ，及其所有的组件？" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) 已成功地从您的计算机移除。"
FunctionEnd

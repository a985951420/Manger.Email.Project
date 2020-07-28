; �ýű�ʹ�� HM VNISEdit �ű��༭���򵼲���

; ��װ�����ʼ���峣��
!define PRODUCT_NAME "�ʼ���������"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "Time"
!define PRODUCT_WEB_SITE "http://www.ntail.cn"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\Email.Windows.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI �ִ����涨�� (1.67 �汾���ϼ���) ------
!include "MUI.nsh"

; MUI Ԥ���峣��
!define MUI_ABORTWARNING
!define MUI_ICON "..\windows.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; ��ӭҳ��
!insertmacro MUI_PAGE_WELCOME
; ���Э��ҳ��
!insertmacro MUI_PAGE_LICENSE "..\Licence.txt"
; ��װĿ¼ѡ��ҳ��
!insertmacro MUI_PAGE_DIRECTORY
; ��װ����ҳ��
!insertmacro MUI_PAGE_INSTFILES
; ��װ���ҳ��
!insertmacro MUI_PAGE_FINISH

; ��װж�ع���ҳ��
!insertmacro MUI_UNPAGE_INSTFILES

; ��װ�����������������
!insertmacro MUI_LANGUAGE "SimpChinese"

; ��װԤ�ͷ��ļ�
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI �ִ����涨����� ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "�ʼ��������ְ�װ��.exe"
InstallDir "$PROGRAMFILES\MailManagementAssistant"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR\MailManagementAssistant"
  SetOverwrite ifnewer
  File /r "..\bin\Release\*.*"
  CreateDirectory "$SMPROGRAMS\�ʼ���������"
  CreateShortCut "$SMPROGRAMS\�ʼ���������\�ʼ���������.lnk" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
  CreateShortCut "$DESKTOP\�ʼ���������.lnk" "$INSTDIR\MailManagementAssistant\Email.Windows.exe"
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
  CreateShortCut "$SMPROGRAMS\�ʼ���������\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\�ʼ���������\Uninstall.lnk" "$INSTDIR\uninst.exe"
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
 *  �����ǰ�װ�����ж�ز���  *
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

  Delete "$SMPROGRAMS\�ʼ���������\Uninstall.lnk"
  Delete "$SMPROGRAMS\�ʼ���������\Website.lnk"
  Delete "$DESKTOP\�ʼ���������.lnk"
  Delete "$SMPROGRAMS\�ʼ���������\�ʼ���������.lnk"

  RMDir "$SMPROGRAMS\�ʼ���������"
  RMDir "$INSTDIR\MailManagementAssistant"

  RMDir /r "$INSTDIR\MailManagementAssistant"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd

#-- ���� NSIS �ű��༭�������� Function ���α�������� Section ����֮���д���Ա��ⰲװ�������δ��Ԥ֪�����⡣--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "��ȷʵҪ��ȫ�Ƴ� $(^Name) ���������е������" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) �ѳɹ��ش����ļ�����Ƴ���"
FunctionEnd

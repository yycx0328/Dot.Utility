
using System;
using System.Text;
using System.IO;

namespace Dot.Utility
{
    /// <summary>
    /// FTP������
    /// </summary>
    public class FTPOperater
    {
        #region ����
        private FTPClient ftp;
        /// <summary>
        /// ȫ��FTP���ʱ���
        /// </summary>
        public FTPClient Ftp
        {
            get { return ftp; }
            set { ftp = value; }
        }

        private string _server;
        /// <summary>
        /// Ftp������
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _User;
        /// <summary>
        /// Ftp�û�
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Pass;
        /// <summary>
        /// Ftp����
        /// </summary>
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }

        private string _FolderZJ;
        /// <summary>
        /// Ftp����
        /// </summary>
        public string FolderZJ
        {
            get { return _FolderZJ; }
            set { _FolderZJ = value; }
        }

        private string _FolderWX;
        /// <summary>
        /// Ftp����
        /// </summary>
        public string FolderWX
        {
            get { return _FolderWX; }
            set { _FolderWX = value; }
        }
        #endregion

   

       

        /// <summary>
        /// �޸��ļ�
        /// </summary>
        /// <param name="ftpFolder">����Ŀ¼</param>
        /// <param name="ftpFileName">�����ļ���temp</param>
        /// <param name="localFolder">����Ŀ¼</param>
        /// <param name="localFileName">�����ļ���</param>
        public bool AddMSCFile(string ftpFolder, string ftpFileName, string localFolder, string localFileName, string BscInfo)
        {
            string sLine = "";
            string sResult = "";
            string path = "���Ӧ�ó������ڵ�������·��";
            path = path.Substring(0, path.LastIndexOf("\\"));
            try
            {
                FileStream fsFile = new FileStream(ftpFolder + "\\" + ftpFileName, FileMode.Open);
                FileStream fsFileWrite = new FileStream(localFolder + "\\" + localFileName, FileMode.Create);
                StreamReader sr = new StreamReader(fsFile);
                StreamWriter sw = new StreamWriter(fsFileWrite);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while (sr.Peek() > -1)
                {
                    sLine = sr.ReadToEnd();
                }
                string[] arStr = sLine.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < arStr.Length - 1; i++)
                {
                    sResult += BscInfo + "," + arStr[i].Trim() + "\n";
                }
                sr.Close();
                byte[] connect = new UTF8Encoding(true).GetBytes(sResult);
                fsFileWrite.Write(connect, 0, connect.Length);
                fsFileWrite.Flush();
                sw.Close();
                fsFile.Close();
                fsFileWrite.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

       

      

        /// <summary>
        ///�õ�FTP�������
        /// </summary>
        public FTPClient getFtpClient()
        {
            FTPClient ft = new FTPClient();
            ft.RemoteHost = this.Server;
            ft.RemoteUser = this.User;
            ft.RemotePass = this.Pass;
            return ft;
        }
    }
}
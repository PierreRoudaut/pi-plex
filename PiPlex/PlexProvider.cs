using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PiPlex
{
    //TODO: to be deprecated when PlexMediaScanner will be tested
    class PlexProvider
    {
        LoggerInterface logger;
        WebBrowser webBrowser;
        HtmlElement updateLibraryElement = null;

        const string PLEX_MEDIA_SERVER_URL = "http://127.0.0.1:32400/web";

        public PlexProvider(LoggerInterface loggerInterface)
        {
            logger = loggerInterface;
            webBrowser = new WebBrowser();
        }

        public void UpdateLibrairy()
        {
            webBrowser = new WebBrowser();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            webBrowser.Navigate(PLEX_MEDIA_SERVER_URL);
        }


        private async void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Debug.WriteLine("loading...");
            //logger.Log("Plex Media Manager loading...");
            var documentElement = webBrowser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested

                await Task.Delay(500);

                // continue polling if the WebBrowser is still busy
                if (webBrowser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }
            //Debug.WriteLine("loaded");
            logger.Log("Plex Media Manager loaded");
            if (SetUpdateLink())
            {
                logger.Log("[Update librairy] button found. Clicking...");
                InovkeUpdate();
            }
            else
            {
                logger.Log("ERROR: [Update librairy] button not found");
            }
        }

        private bool SetUpdateLink()
        {
            HtmlElementCollection all = this.webBrowser.Document.All;
            foreach (HtmlElement element in all)
            {
                if (element.GetAttribute("className") == "update-btn")
                {
                    updateLibraryElement = element;
                    return true;
                }
            }
            return false;
        }

        private void InovkeUpdate()
        {
            if (updateLibraryElement != null)
            {
                Object value = updateLibraryElement.InvokeMember("Click");
                logger.Log("Plex librairy is now updating...");
            }
            else
            {
                logger.Log("ERROR: [Update librairy] has not been set");
            }
        }

    }
}

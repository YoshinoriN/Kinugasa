using System;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace Kinugasa.Uwp.Web.Feed
{
    /// <summary>
    /// Provide feature of download feed from url.
    /// </summary>
    public class Downloader
    {
        /// <summary>
        /// Download RSS feed and return <see cref="SyndicationFeed"/> object.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/></param>
        /// <returns><see cref="SyndicationFeed"/> object.</returns>
        public async Task<SyndicationFeed> DownloadFeedsAsync(Uri uri)
        {
            var syndicationClient = new SyndicationClient();

            try
            {
                return await syndicationClient.RetrieveFeedAsync(uri);
            }
            catch (Exception ex)
            {
                throw new System.Net.Http.HttpRequestException(ex.Message, ex);
            }
        }
    }
}

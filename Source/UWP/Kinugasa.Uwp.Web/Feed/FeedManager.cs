using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace Kinugasa.Uwp.Web.Feed
{
    /// <summary>
    /// Provide feature of create feed items from RSS or Atom.
    /// </summary>
    public class FeedManager
    {
        /// <summary>
        /// Feeds of current website.
        /// </summary>
        public IList<Feed> CurrentWebSiteFees { get; private set; } = new List<Feed>();

        /// <summary>
        /// Feeds of all website if you specified some website.
        /// </summary>
        public IList<Feed> AllWebSitesFeeds { get; private set; } = new List<Feed>();

        /// <summary>
        /// Limit of number of download feeds.
        /// </summary>
        private int _limitOfFeeds { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public FeedManager()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="limitOfFeeds">Can specify limit of get number of feeds.</param>
        public FeedManager(int limitOfFeeds)
        {
            this._limitOfFeeds = limitOfFeeds;
        }

        /// <summary>
        /// Get feed of specified uri's feed.
        /// </summary>
        /// <param name="uri">URL</param>
        /// <returns><see cref="IList{Feed}"/> of <see cref="Feed"/></returns>
        public async Task<List<Feed>> GetFeeds(System.Uri uri)
        {
            var downloadedFeeds = new Downloader();
            var result = await downloadedFeeds.DownloadFeedsAsync(uri);
            return this.GetFeeds(result);
        }

        /// <summary>
        /// Get feed of specified uri's feed by URL.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns><see cref="IList{Feed}"/> of <see cref="Feed"/></returns>
        public async Task<List<Feed>> GetFeeds(string url)
        {
            var downloadedFeeds = new Downloader();
            var result = await downloadedFeeds.DownloadFeedsAsync(url);
            return this.GetFeeds(result);
        }

        /// <summary>
        /// Create feed list.
        /// </summary>
        /// <param name="feeds"><see cref="SyndicationFeed"/></param>
        /// <returns><see cref="IList{Feed}"/></returns>
        private List<Feed> GetFeeds(SyndicationFeed feeds)
        {
            this.CurrentWebSiteFees.Clear();
            int i = 1;
            foreach (var feed in feeds.Items)
            {
                if (_limitOfFeeds < i)
                {
                    this.AddAllWebSiteFeeds(this.CurrentWebSiteFees);
                    return CurrentWebSiteFees.ToList();
                }
                CurrentWebSiteFees.Add(new Feed(feed));
                i++;
            }
            this.AddAllWebSiteFeeds(this.CurrentWebSiteFees);
            return CurrentWebSiteFees.ToList();
        }

        /// <summary>
        /// Create all website's <see cref="IList{Feed}"/> <>
        /// </summary>
        /// <param name="feeds"><see cref="IList{Feed}"/></param>
        private void AddAllWebSiteFeeds(IList<Feed> feeds)
        {
            foreach (var feed in feeds)
            {
                this.AllWebSitesFeeds.Add(feed);
            }
        }

        /// <summary>
        /// Clear all website's feeds.
        /// </summary>
        public void RefreshAllWebSiteFeeds()
        {
            this.CurrentWebSiteFees.Clear();
            this.AllWebSitesFeeds.Clear();
        }
    }
}

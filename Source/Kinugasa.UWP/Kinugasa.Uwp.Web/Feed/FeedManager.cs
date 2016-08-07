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
        /// Hack : To user can setting using by something setting file.
        /// </summary>
        private int _limitOfFees { get; set; } = 10;

        /// <summary>
        /// Get feed of specified uri's feed.
        /// </summary>
        /// <param name="uri">URL</param>
        /// <returns><see cref="IList{T}"/> of <see cref="Feed"/></returns>
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
        /// <returns><see cref="IList{T}"/> of <see cref="Feed"/></returns>
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
            foreach (var feed in feeds.Items)
            {
                int i = 0;
                if (_limitOfFees > i)
                {
                    this.AddAllWebSiteFeeds(this.CurrentWebSiteFees);
                    return CurrentWebSiteFees.ToList();
                }
                CurrentWebSiteFees.Add(new Feed(feed.Id
                                     , feed.BaseUri
                                     , feed.Title.ToString()
                                     , feed.Summary.ToString()
                                     , feed.Categories.ToList()
                                     , feed.Authors.ToList()
                                     , feed.Links.ToList()
                                     , feed.PublishedDate
                                     , feed.LastUpdatedTime
                                     ));
                this._limitOfFees++;
            }
            this.AddAllWebSiteFeeds(this.CurrentWebSiteFees);
            return CurrentWebSiteFees.ToList();
        }

        /// <summary>
        /// Create all website's <see cref="IList{T}"/> <>
        /// </summary>
        /// <param name="feeds"><see cref="IList{Feed}"/></param>
        private void AddAllWebSiteFeeds(IList<Feed> feeds)
        {
            foreach (var feed in feeds)
            {
                this.AllWebSitesFeeds.Add(new Feed(feed.Id
                                     , feed.BaseUri
                                     , feed.Title.ToString()
                                     , feed.Summary.ToString()
                                     , feed.Categories.ToList()
                                     , feed.Authors.ToList()
                                     , feed.Links.ToList()
                                     , feed.PublishDate
                                     , feed.LastUpdatedTime
                                     ));
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

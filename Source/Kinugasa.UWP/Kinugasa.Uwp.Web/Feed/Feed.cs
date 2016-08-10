using System;
using Windows.Web.Syndication;

namespace Kinugasa.Uwp.Web.Feed
{
    /// <summary>
    /// Content of RSS or Atom feed.
    /// Wrapp of <see cref="SyndicationItem"/> class.
    /// </summary>
    public class Feed
    {
        #region properties

        public string Id { get; }

        /// <summary>
        /// Base uri of feed.
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// Title of feed.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Summary of feed.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Publish of date.
        /// </summary>
        public DateTimeOffset PublishDate { get; }

        /// <summary>
        /// Last update of feed.
        /// </summary>
        public DateTimeOffset LastUpdatedTime { get; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item"><see cref="SyndicationItem"/></param>
        public Feed(SyndicationItem item)
        {
            this.Id = item.Id;
            this.BaseUri = item.BaseUri;
            this.Title = item.Title.Text.ToString();
            this.Summary = item.Summary.Text.ToString();
            this.PublishDate = item.PublishedDate;
            this.LastUpdatedTime = item.LastUpdatedTime;
        }

    }
}

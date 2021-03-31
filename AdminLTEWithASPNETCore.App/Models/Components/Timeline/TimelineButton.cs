using AdminLTEWithASPNETCore.Enums;
using AdminLTEWithASPNETCore.Extensions;

namespace AdminLTEWithASPNETCore.Models.Components.Timeline
{
    /// <summary>
    /// Class TimelineButton.
    /// </summary>
    public class TimelineButton
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the type of the button.
        /// </summary>
        /// <value>The type of the button.</value>
        public ButtonType ButtonType { get; set; } = ButtonType.Primary;
        /// <summary>Gets or sets the URL target.</summary>
        /// <value>The URL target (_self is default)</value>
        /// <remarks>
        ///   <list type="table">
        ///     <item>
        ///       <description>
        ///         <strong>Value</strong>
        ///       </description>
        ///       <description>
        ///         <strong>Description</strong>
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>_blank<br /></description>
        ///       <description>Opens the linked document in a new window or tab</description>
        ///     </item>
        ///     <item>
        ///       <description>_self </description>
        ///       <description>Opens the linked document in the same frame as it was clicked (this is default)</description>
        ///     </item>
        ///     <item>
        ///       <description>_parent</description>
        ///       <description>Opens the linked document in the parent frame</description>
        ///     </item>
        ///     <item>
        ///       <description>_top</description>
        ///       <description>Opens the linked document in the full body of the window</description>
        ///     </item>
        ///     <item>
        ///       <description>framename </description>
        ///       <description>Opens the linked document in the named iframe</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string UrlTarget { get; set; } = "_self";
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets the button type text.
        /// </summary>
        /// <value>The button type text.</value>
        public string ButtonTypeText => ButtonType.GetDescription();
    }
}
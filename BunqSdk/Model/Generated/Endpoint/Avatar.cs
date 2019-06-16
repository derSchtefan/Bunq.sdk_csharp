using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Avatars are public images used to represent you or your company. Avatars are used to represent users, monetary
    /// accounts and cash registers. Avatars cannot be deleted, only replaced. Avatars can be updated after uploading
    /// the image you would like to use through AttachmentPublic. Using the attachment_public_uuid which is returned you
    /// can update your Avatar. Avatars used for cash registers and company accounts will be reviewed by bunq.
    /// </summary>
    public class Avatar : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "avatar";

        protected const string ENDPOINT_URL_READ = "avatar/{0}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ATTACHMENT_PUBLIC_UUID = "attachment_public_uuid";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "Uuid";

        private const string OBJECT_TYPE_GET = "Avatar";

        /// <summary>
        /// The public UUID of the public attachment from which an avatar image must be created.
        /// </summary>
        [JsonProperty(PropertyName = "attachment_public_uuid")]
        public string AttachmentPublicUuid { get; set; }

        /// <summary>
        /// The UUID of the created avatar.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The content type of the image.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public List<Image> Image { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="attachmentPublicUuid">The public UUID of the public attachment from which an avatar image must be created.</param>
        public static BunqResponse<string> Create(string attachmentPublicUuid,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_ATTACHMENT_PUBLIC_UUID, attachmentPublicUuid},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return ProcessForUuid(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<Avatar> Get(string avatarUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, avatarUuid),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Avatar>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }

            if (this.Image != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Avatar CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Avatar>(json);
        }
    }
}
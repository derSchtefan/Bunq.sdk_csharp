using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TabVisibility : BunqModel
    {
        /// <summary>
        /// When true the tab will be linked to the ACTIVE cash registers QR code.
        /// </summary>
        [JsonProperty(PropertyName = "cash_register_qr_code")]
        public bool? CashRegisterQrCode { get; set; }

        /// <summary>
        /// When true the tab will be visible through its own QR code. Use ../tab/{tab-id}/qr-code-content to get the
        /// raw content of this QR code
        /// </summary>
        [JsonProperty(PropertyName = "tab_qr_code")]
        public bool? TabQrCode { get; set; }

        /// <summary>
        /// The location of the Tab in NearPay.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Geolocation Location { get; set; }


        public TabVisibility(bool? cashRegisterQrCode, bool? tabQrCode)
        {
            CashRegisterQrCode = cashRegisterQrCode;
            TabQrCode = tabQrCode;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.CashRegisterQrCode != null)
            {
                return false;
            }

            if (this.TabQrCode != null)
            {
                return false;
            }

            if (this.Location != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TabVisibility CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabVisibility>(json);
        }
    }
}
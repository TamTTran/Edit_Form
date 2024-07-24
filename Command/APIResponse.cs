using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edit_Info.Command
{
    public class APIResponse<T>
    {
        #region Public Properties

        /// <summary>
        /// Indicates if the API call was successful
        /// </summary>
        public bool Successful
        {
            get
            {
                if (Response == null && ResponseList == null && PdfContent == null)
                    return false;

                return ErrorMessage == null;
            }
        }

        /// <summary>
        /// The error message for a failed API call
        /// </summary>
        public string ErrorMessage { get; set; }

        public string InnerException { get; set; }

        /// <summary>
        /// The API response object
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// The API response object
        /// </summary>
        public IList<T> ResponseList { get; set; }

        public byte[] PdfContent { get; set; }

        public string filename { get; set; }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public APIResponse()
        {
        }

        #endregion Constructor
    }
}

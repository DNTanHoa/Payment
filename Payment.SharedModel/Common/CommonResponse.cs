using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.SharedModel.Common
{
    public class CommonResponse
    {
        public CommonResult result { get; set; }
        public Object data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public CommonResponse SetResult(CommonResult result)
        {
            this.result = result;
            return this;
        }
        public CommonResponse SetData(object data)
        {
            this.data = data;
            return this;
        }
        public CommonResponse GetCreateSuccessResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "success",
                code = "Create successfully for " + additional
            };
            return this;
        }
        public CommonResponse GetUpdateSuccessResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "success",
                code = "Update successfully for " + additional
            };
            return this;
        }
        public CommonResponse GetDeleteSuccessResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "success",
                code = "Delete successfully for " + additional
            };
            return this;
        }
        public CommonResponse GetCreateFailedResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "error",
                code = "Create failed for " + additional
            };
            return this;
        }
        public CommonResponse GetUpdateFailedResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "error",
                code = "Update failed for " + additional
            };
            return this;
        }
        public CommonResponse GetDeleteFailedResponse(string additional = "")
        {
            this.result = new CommonResult()
            {
                message = "error",
                code = "Delete failed for " + additional
            };
            return this;
        }
    }
}

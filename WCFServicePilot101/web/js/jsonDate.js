//注意时区问题

if (JSON && !JSON.parseWithDate) {
    var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)Z$/;
    var reMsAjax = /^\/Date\((\d*)([\+\-]\d*)?\)[\/|\\]$/;

    JSON.parseWithDate = function(json) {
        /// <summary>
        /// parses a JSON string and turns ISO or MSAJAX date strings
        /// into native JS date objects
        /// </summary>    
        /// <param name="json" type="var">json with dates to parse</param>        
        /// </param>
        /// <returns type="value, array or object" />
        try {
            var res = JSON.parse(json,
            function(key, value) {

                if (typeof value === 'string') {
                    var a = reISO.exec(value);
                    if (a)
                        return new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4], +a[5], +a[6]));
                    a = reMsAjax.exec(value);
                    if (a) {
                        var b = +a[1];
                        if(a[2]){                           //包含时区信息
                            b = b - a[2]/100*3600*1000;     //修正时区信息
                        }
                        return new Date(b);
                    }
                }
                return value;
            });
            return res;
        } catch (e) {
            // orignal error thrown has no error message so rethrow with message
            throw new Error("JSON content could not be parsed");
            return null;
        }
    };
    JSON.stringifyWcf = function(json) {
        return JSON.stringify(json, function(key, value) {
            if (typeof value == "string") {
                var a = reISO.exec(value);
                if (a) {
                    var d = new Date();
                    var timeZone = -d.getTimezoneOffset()/60;
                    var val = '/Date(' + new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4]+timeZone, +a[5], +a[6])).getTime() + ')/';
                    //this[key] = val;
                    return val; 
                }
            }
            return value;
        })
    };
    JSON.dateStringToDate = function(dtString) {
        /// <summary>
        /// Converts a JSON ISO or MSAJAX string into a date object
        /// </summary>    
        /// <param name="" type="var">Date String</param>
        /// <returns type="date or null if invalid" /> 
        var a = reISO.exec(dtString);
        if (a)
            return new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4], +a[5], +a[6]));
        a = reMsAjax.exec(dtString);
        if (a) {
            var b = +a[1];
            if(a[2]){
                var d = new Date();
                var timeZone = -d.getTimezoneOffset()/60;   //当地时区
                b = b + (timeZone - a[2]/100)*3600*1000;
            }
            return new Date(b);
        }
        return null;
    };
}

//将ISO和.NET型日期字符串转换成正确的javascript类型
var dateReviver = function (key, value){
    //ISO 8610格式：yyyy-MM-ddTHH:mm:ss.fffZ
    var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)Z$/;
    //.NET格式：\/Date(1270051200000+0800)\/
    var reMsAjax = /^\/Date\((\d*)([\+\-]\d*)?\)[\/|\\]$/;
    var a;
    if (typeof value === 'string') {
        var a = reISO.exec(value);
        if (a)
            return new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4], +a[5], +a[6]));
        a = reMsAjax.exec(value);
        if (a) {
            var b = +a[1];
            if(a[2]){                                   //包含时区信息
                b = b - a[2]/100*3600*1000;             //修正时区信息
            }
            return new Date(b);
        }
    }
    return value;
}

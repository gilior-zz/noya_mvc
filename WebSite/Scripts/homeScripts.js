//$(document).ready(function () {

var createEventManager = function () {
    var d = new Date();
    var m = d.getMonth() + 1;
    var y = d.getFullYear();
    var currentDate = { month: m, year: y };
    function getPrevItem(isHebrew) {

        $.ajax({
            async: true,
            type: "Post",
            url: isHebrew ? "Home/GetNextEvent" : "Home/GetPrevEvent",
            contentType: "application/json",
            data: JSON.stringify({
                month: currentDate.month, year: currentDate.year
            }),
            dataType: "json",
            success: function (result) {
                //alert("suc   " + result.responseText);
                //var obj = JSON.parse(result.responseText);
                currentDate.month = result.Month;
                currentDate.year = result.Year;
                var calendarText = result.Month + '/' + result.Year;
                var calendatData = result.Data;
                if (!result.HasNext)
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'visible');
                if (!result.HasPrev)
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'visible');
                //$("#calendarDate").text(calendarText);
                setTextByLan(isHebrew);
                $("#calendarData").html(calendatData);
                $("#calendarData").scrollTop(0);
            },
            error: function (result) {
                alert("err  " + result.responseText);
            }
        });
    }
    function getNextItem(isHebrew) {

        $.ajax({
            async: true,
            type: "Post",
            url: isHebrew ? "Home/GetPrevEvent" : "Home/GetNextEvent",
            contentType: "application/json",
            data: JSON.stringify({
                month: currentDate.month, year: currentDate.year
            }),
            dataType: "json",
            success: function (result) {
                //alert("suc   " + result.responseText);
                //var obj = JSON.parse(result);
                currentDate.month = result.Month;
                currentDate.year = result.Year;
                var calendarText = result.Month + '/' + result.Year;
                var calendatData = result.Data;
                if (!result.HasNext)
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'visible');
                if (!result.HasPrev)
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'visible');
                //$("#calendarDate").text(calendarText);
                setTextByLan(isHebrew);
                $("#calendarData").html(calendatData);
                $("#calendarData").scrollTop(0);
            },
            error: function (result) {
                alert("err  " + result.responseText);
            }
        });
    }

    function getCurrentItem(isHebrew) {

        $.ajax({
            async: true,
            type: "Post",
            url: "Home/GetCurrentEvent",
            contentType: "application/json",
            data: JSON.stringify({
                month: currentDate.month, year: currentDate.year
            }),
            dataType: "json",
            success: function (result) {
                //alert("suc   " + response.responseText);
                //var obj = JSON.parse(result);
                currentDate.month = result.Month;
                currentDate.year = result.Year;
                var calendarText = result.Month + '/' + result.Year;
                var calendatData = result.Data;
                if (!result.HasNext)
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#prevNav" : "#nextNav").css('visibility', 'visible');
                if (!result.HasPrev)
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'hidden');
                else
                    $(isHebrew ? "#nextNav" : "#prevNav").css('visibility', 'visible');
                //$("#calendarDate").text(calendarText);
                setTextByLan(isHebrew);
                $("#calendarData").html(calendatData);
                $("#calendarData").scrollTop(0);
            },
            error: function (result) {
                alert("err  " + result.responseText);
            }
        });
    }

    function setHebText() {
        var name = hebMonths[currentDate.month];
        var calendarText = name + ' ' + currentDate.year;
        $("#calendarDate").text(calendarText);
    }

    function setEngText() {
        var name = engMonths[currentDate.month];
        var calendarText = name + ' ' + currentDate.year;
        $("#calendarDate").text(calendarText);
    }
    function setTextByLan(hebrew) {
        switch (hebrew) {
            case true:
                setHebText();
                break;
            case false:
                setEngText();
                break;

        }
    }


    var engMonths = {
        1: "January", 2: "February", 3: "March", 4: "April", 5: "May", 6: "June",
        7: "July", 8: "August", 9: "September", 10: "October", 11: "November", 12: "December"
    };
    var hebMonths = {
        1: "ינואר", 2: "פברואר", 3: "מרץ", 4: "אפריל", 5: "מאי", 6: "יוני",
        7: "יולי", 8: "אוגוסט", 9: "ספטמבר", 10: "אוקטובר", 11: "נובמבר", 12: "דצמבר"
    };

    return {
        getPrevItem: getPrevItem,
        getNextItem: getNextItem,
        getCurrentItem: getCurrentItem,
        setHebText: setHebText,
        setEngText: setEngText,
        setTextByLan: setTextByLan
    }
}
var createPoststManager = function () {
    var getPosts = function () {
        $.ajax({
            async: true,
            type: "Post",
            url: "Home/GePosts",
            contentType: "application/json",

            dataType: "json",
            success: function (result) {
                $("#postsData").html(result);
            },
            error: function (result) {
                alert("err  " + result.responseText);
            }
        });
    }
    return {
        getPosts: getPosts
    }
}

eventManager = createEventManager();
postsManager = createPoststManager();
//eventManager.getCurrentItem();

//});






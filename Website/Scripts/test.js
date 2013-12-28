    var threadId = 1;
    var date = new Date();

    $(document).ready(function () {
        //lunch sync thread
        threadId = setInterval(function () {
            syncNotes();
        }, 15000); //thread sleep 15 sec
    });

    function syncNotes(all) {
        $("#loaderAnim").show();
        var lastId = $("ol#update li:first");
        if (lastId[0]) { //get last inserted id on this session 
            lastId = lastId.attr("id").replace("bar-", "");
        } else {
            lastId = 0;
        }
        $.ajax({
            type: "GET",
            url: "TextNotes/GetLatestNotes",
            data: { lastId: lastId, lastDate: dateFormat(date, 'isoUtcDateTime') },
            cache: false,
            dataType: "json",
            success: function (data) {
                date = new Date();
                if (data.Html) { //show latest notes
                    $("ol#update").prepend(data.Html);
                    $("ol#update li").slideDown("slow");
                } else { }
                $("#loaderAnim").hide();
            },
            error: function () {
                //stop thread - server is offline
                clearInterval(threadId);
                $("#loaderAnim").hide();
            }
        });
    };
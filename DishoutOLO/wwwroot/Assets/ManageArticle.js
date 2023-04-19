

$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    $("#btn-Add ").on("click", function () {
        $("#lblError").removeClass("success").removeClass("error").text('');
        var retval = true;
        $("#myForm .required").each(function () {
            if (!$(this).val()) {
                $(this).addClass("error");
                retval = false;
            }
            else {
                $(this).removeClass("error");
            }
        });
        if (retval) {
            var data = {
                id: $("#Id").val(),
                ArticleName: $("#ArticleName").val(),
                ArticleDescription: $("#ArticleDescription").val(),
                IsActive: $("#IsActive").val() == "true" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/Article/AddOrUpdateArticle",
                data: { articleVM: data },
                success: function (data) {
                    debugger
                    console.log(data);
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();
                        toastr.success('Article Added Successfully.')

                    }
                    else {
                        window.location.href = '/Article/Index'

                    }
                }
            });
        }

    })
   

});


$(document).ready(function () {
    var editor = $('#summernote');
    editor.summernote({
        height: ($(window).height() - 250),
        focus: false,
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', ['strikethrough']],
            ['fontsize', ['fontsize']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['height', ['height']],
            ['view', ['fullscreen', 'codeview']],
        ],
        oninit: function () {
            // Add "open" - "save" buttons
            var noteBtn = '<button id="makeSnote" type="button" class="btn btn-default btn-sm btn-small" title="Identify a music note" data-event="something" tabindex="-1"><i class="fa fa-music"></i></button>';
            var fileGroup = '<div class="note-file btn-group">' + noteBtn + '</div>';
            $(fileGroup).appendTo($('.note-toolbar'));
            // Button tooltips
            $('#makeSnote').tooltip({ container: 'body', placement: 'bottom' });
            // Button events
            $('#makeSnote').click(function (event) {
                var highlight = window.getSelection(),
                    spn = document.createElement('span'),
                    range = highlight.getRangeAt(0)

                spn.innerHTML = highlight;
                spn.className = 'snote';
                spn.style.color = 'blue';

                range.deleteContents();
                range.insertNode(spn);
            });
        },

    });

});
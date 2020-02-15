$(document).ready(function () {

    var elements = [];

    $.ajax({
        url: 'Home/GetRoots',
        success: function (data) {
            CreateChildrenHtml(data, $("#root"));
        },
        error: function (e) {
            console.log(e)
        }
    })

    function ShowHideChildren(parentId, parentHtmlElement) {
        if (elements.findIndex(x => x.ParentId == parentId) == -1) {
            $.ajax({
                url: 'Home/GetChildrenByParentId',
                data: { parentId: parentId },
                success: function (data) {
                    CreateChildrenHtml(data, parentHtmlElement);
                    //if (data.length == 0) {
                    //    $("[data-guidBtn=" + parentId + "]").remove();
                    //}
                },
                error: function (e) {
                    console.log(e)
                }
            })
        }

        if (elements.findIndex(x => x.ParentId == parentId) != -1) {
            var li = $("[data-guid=" + parentId + "]")[0]
            var isExpanded = $(li).children("ul").css("display") != "none"

            if (isExpanded)
                $(li).children("ul").css("display", "none")
            else
                $(li).children("ul").css("display", "block")
        }
    }

    function CreateChildrenHtml(childrenData, parentHtmlElement) {
        if (childrenData.length > 0) {
            var ul = document.createElement("ul");
            for (var i = 0; i < childrenData.length; i++) {
                var li = document.createElement("li");
                li.innerHTML = childrenData[i].Value;
                li.setAttribute("data-guid", childrenData[i].Guid);

                var btn = document.createElement("button");
                btn.innerHTML = ">"
                btn.setAttribute("data-guidBtn", childrenData[i].Guid);
                $(btn).on("click", function (e) {
                    console.log($(e.target).attr("data-guidBtn"))
                    var id = $(e.target).attr("data-guidBtn")
                    var parent = $("[data-guid=" + id + "]");
                    ShowHideChildren(id, parent);
                })

                $(li).append(btn);
                $(ul).append(li);
                elements.push(childrenData[i]);

                var input = document.createElement('input');
                input.type = 'text'
                input.placeholder = "Add element"
                input.setAttribute("data-guidInput", childrenData[i].Guid)

                $(input).on("keypress", function (e) {
                    if (e.which == 13) {
                        var value = e.currentTarget.value;
                        var parentEl = $(e)[0].target.getAttribute("data-guidInput")
                        AddNewElement(value, parentEl);
                    }
                })
                $(li).append(input)
            }

            $(parentHtmlElement).append(ul);
        }
    }

    function AddNewElement(elementValue,parentId) {
        console.log(elementValue, parentId)
        
        $.ajax({
            url: "Home/AddElement",
            data: {
                Value: elementValue,
                ParentId: parentId
            },
            success: function (e) {
                
                var parent = $("[data-guid=" + parentId + "]");
                CreateChildrenHtml([e], parent)
            },
            error: function (e) {
                console.log(e);
            }
        })
    }

})
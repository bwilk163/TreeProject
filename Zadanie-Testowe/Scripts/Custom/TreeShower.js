elements = []

function AddElement(e) {
    elements.push(e);
}
function AddElements(list) {
    for (var i = 0; i < list.length;i++)
    elements.push(list[i]);
}
function HasElement(guid) {
    var id = elements.findIndex(x => x == guid);
    if (id == -1)
        return false;
    return true;
}

var dragged = null;
function SetDraggedElement(e) {
    dragged = $(e.target).attr("data-elementcontainer");
}

function OnDragEnd(e) {
    var p = $(e.target);
    var newId =null
    if (p.attr("data-elementcontainer"))
        newId = p.attr("data-elementcontainer");
    if (p.attr("data-display"))
        newId = p.attr("data-display")

    if (dragged != newId) {
        var draggedEl = $("[data-id=" + dragged + "]")[0];
        console.log("draging ", draggedEl);
        var newEl = $("[data-parent=" + newId + "] > ul")[0];

        $.ajax({
            url: "/Home/ChangeParent",
            data: { treeElement: dragged, newParent: newId },
            success: function (e) {
                // if ok
                if (e) {
                    newEl.appendChild(draggedEl);
                }
            }

        })
    }
}

function OnDragOver(e) {
    e.preventDefault();

}
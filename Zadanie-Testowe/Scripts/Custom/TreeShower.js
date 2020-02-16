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

function SetDraggedElement(e) {
    console.log("Dragged", e);
    
}

function OnDragEnd(e) {
    console.log("OnDrop", e.target.getAttribute("data-elementContainer"));


    e.preventDefault();
}
var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("idCategoria");


    if (id.value > 0) {
        $('#exampleModal').modal('show');
    }
});


function limpiar() {
    var cat = document.getElementById("nombreCat");
    var id = document.getElementById("idCategoria");

    id.value = 0;
    cat.value = "";
}



function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "language": {
            search: "Buscar",
            processing: "Cargando datos..",

        },
        "responsive": true,
        "ajax": {
            "url":"/Categoria/GetAll"
        },
        "columns": [
            { "data": "idCatgoria", "with":"10%"},
            {
                "data":"nombre","width":"60%"
            },
            {
                "data": "idCatgoria",
                "render": function (data) {
                    return `
                        <div style="display: flex;justify-content: space-around;">
                        <a href="/Categoria/Index/${data}" class="btn btn-success text-white" style="cursor:pointer;" >Editar</a>
                        <a onclick=Delete("/Categoria/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer;">Eliminar</a>
                        
                        </div>
                    `;
                },
                "width":"20%"
            }
        ]
    })
}


function Delete(url) {
    Swal.fire({
        title: "Esta seguro de eliminar esta categoria?",
        text: "No se podra recuperar una vez eliminado",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,eliminar',
        cancelButtonText: 'No, cancelar!',

    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        alert(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        alert(data.message)
                    }
                }
            })
        }
    })
}

//For callback a function for the column convert or other method
//datatabl = $('#tblData').DataTable({
//    "ajax": {
//        "url": "/Categoria/GetAll"
//    },
//    "columns": [
//        {
//            "data": "nombre", "width": "50%",
//        },
//        {
//            "data":"estao",
//            "render": function (data) {
//                if (data == true) {
//                    return "Activo";
//                }
//                else {
//                    return "Inactivo";
//                }
//            },
//            "width":"50%",
//        }
//    ]
//})
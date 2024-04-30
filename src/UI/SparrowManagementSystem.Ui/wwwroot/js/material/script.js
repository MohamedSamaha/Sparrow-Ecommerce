function createMaterial() {
	var materialName = document.getElementById('materialNameId').value;
	var materialType = document.getElementById('materialTypeId').value;
	var materialDescription = document.getElementById('materialDescriptionId').value;
	var supplierName = document.getElementById('materialSupplierId').value;
	var materialCode = document.getElementById('materialCodeId').value;

	if (materialName === '' || materialType === '' || materialDescription === '' || supplierName === '' || materialCode === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Material/Create", data: {
				materialName: materialName,
				materialType: materialType,
				materialDescription: materialDescription,
				supplierName: supplierName,
				materialCode: materialCode
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Material Successfully Added!", `Material name: ${materialName} of Type : ${materialType} And Description ${materialDescription}`, {
					icon: "success",
					buttons: {
						confirm: {
							className: 'btn btn-success'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}, error: function (error) {
				swal('Something Went Wrong!', {
					icon: "error",
					buttons: {
						confirm: {
							className: 'btn btn-error'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}
		});

		document.getElementById('dangerAlert').hidden = true;
		materialName = '';
		materialType = '';
		materialDescription = '';
		supplierName = '';
		materialCode = '';

	}
}

function deleteMaterialFunc(Id) {
	swal({
		title: 'Are you sure?',
		text: "You won't be able to revert this!",
		type: 'warning',
		buttons: {
			cancel: {
				visible: true,
				text: 'No, cancel!',
				className: 'btn btn-success'
			},
			confirm: {
				text: 'Yes, delete it!',
				className: 'btn btn-danger'
			}
		}
	}).then((willDelete) => {


		if (willDelete) {
			$.ajax({
				type: 'POST', url: "/Material/Delete", data: {
					Id: Id
				}, success: function () {
					window.location.reload();
				}, error: function (error) {

				}
			});
			swal("Poof! Your imaginary file has been deleted!", {
				icon: "success",
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		} else {
			swal("Your imaginary file is safe!", {
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		}
	});

}

function editMaterial(Id) {
	var materialName = document.getElementById(`materialNameId-${Id}`).value;
	var materialType = document.getElementById(`materialTypeId-${Id}`).value;
	var materialDescription = document.getElementById(`materialDescriptionId-${Id}`).value;
	var supplierName = document.getElementById(`materialSupplierId-${Id}`).value;
	var materialCode = document.getElementById(`materialCodeId-${Id}`).value;

	if (materialName === '' || materialType === '' || materialDescription === '' || supplierName === '' || materialCode === '') {

		document.getElementById('dangerEditAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Material/Edit", data: {
				materialName: materialName,
				materialType: materialType,
				materialDescription: materialDescription,
				supplierName: supplierName,
				materialCode: materialCode,
				Id: Id
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Material Successfully Updated", {
					icon: "success",
					buttons: {
						confirm: {
							className: 'btn btn-success'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}, error: function (error) {
				swal('Something Went Wrong!', {
					icon: "error",
					buttons: {
						confirm: {
							className: 'btn btn-error'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}
		});
	}



}
$(document).ready(function () {
	$('#basic-datatables').DataTable({
	});

	$('#multi-filter-select').DataTable({
		"pageLength": 5,
		initComplete: function () {
			this.api().columns().every(function () {
				var column = this;
				var select = $('<select class="form-control"><option value=""></option></select>')
					.appendTo($(column.footer()).empty())
					.on('change', function () {
						var val = $.fn.dataTable.util.escapeRegex(
							$(this).val()
						);

						column
							.search(val ? '^' + val + '$' : '', true, false)
							.draw();
					});

				column.data().unique().sort().each(function (d, j) {
					select.append('<option value="' + d + '">' + d + '</option>')
				});
			});
		}
	});

	// Add Row
	$('#add-row').DataTable({
		"pageLength": 5,
	});

	var action = '<td> <div class="form-button-action"> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-primary btn-lg" data-original-title="Edit Task"> <i class="fa fa-edit"></i> </button> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-danger" data-original-title="Remove"> <i class="fa fa-times"></i> </button> </div> </td>';

	$('#addRowButton').click(function () {
		$('#add-row').dataTable().fnAddData([
			$("#materialNameId").val(),
			$("#materialTypeId").val(),
			$("#materialDescriptionId").val(),
			$("#materialSupplierId").val(),
			$("#materialCodeId").val(),
			action
		]);
		$('#addRowModal').modal('hide');

	});
});

function hardRefresh() {   // Create a new KeyboardEvent with the key property set to "F5" and Ctrl key pressed 
	var event = new KeyboardEvent('keydown', { key: 'F5', code: 'F5', keyCode: 116, ctrlKey: true, metaKey: true, });   // Dispatch the event to the document 
	document.dispatchEvent(event);
}

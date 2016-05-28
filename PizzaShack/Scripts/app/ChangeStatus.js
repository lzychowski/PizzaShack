$(document).ready(function () {

	$(".btn-change-status").on("click", function () {
		$("#modal-body-error").addClass("hide");
		$("#btn-change-status-submit").attr("data-id", $(this).data("id"));
		$("#input-change-status").val($(this).data("status"));
	});

	$("#btn-change-status-submit").on("click", function () {
		$.ajax({
			type: "POST",
			url: location.protocol
				+ "//" + location.host
				+ "/orders/" + $(this).data("id")
				+ "/status/" + $("#input-change-status").val(),
			success: function (data) {
				console.log("success");
				$("#modal-change-status").addClass("fade");
				window.location.href = windowLocation;
			},
			error: function (ex) {
				console.log("error");
				$("#modal-body-error").removeClass("hide");
			}
		});
	});

	$("#table-all-orders").dataTable({
		"order": [[3, "asc"]]
	});
});
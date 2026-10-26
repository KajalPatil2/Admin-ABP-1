$(function () {
    var l = abp.localization.getResource('Admin');
    var createModal = new abp.ModalManager(abp.appPath + 'Newspapers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Newspapers/EditModal');

    var dataTable = $('#NewspapersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, 'asc']],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.admin.newspapers.newspaper.getList),
            columnDefs: [
                {
                    title: 'Actions',
                    rowAction: {
                        items: [
                            {
                                text: 'Edit',
                                visible: abp.auth.isGranted('Admin.Newspapers.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: 'Delete',
                                visible: abp.auth.isGranted('Admin.Newspapers.Delete'),
                                confirmMessage: function (data) {
                                    return 'Delete ' + data.record.name + '?';
                                },
                                action: function (data) {
                                    acme.admin.newspapers.newspaper
                                        .delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info('Deleted');
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                { title: 'Name', data: 'name' },
                { title: 'Code', data: 'code' },
                {
                    title: 'Active',
                    data: 'isActive',
                    render: function (data) { return data ? 'Yes' : 'No'; }
                }
            ]
        })
    );

    createModal.onResult(function () { dataTable.ajax.reload(); });
    editModal.onResult(function () { dataTable.ajax.reload(); });

    $('#NewNewspaperButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
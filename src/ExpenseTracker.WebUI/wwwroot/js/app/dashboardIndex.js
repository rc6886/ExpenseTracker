(function () {
    $('#editable-select').editableSelect();

    axios.get('/dashboard/transactions')
        .then(function (response) {
            initializeVue(response.data.transactions);
        });

    function initializeVue(transactions) {
        new Vue({
            el: '#dashboardIndex',
            data: {
                transactions: transactions,
                showModal: false,
                addTransactionCommand: {
                    vendorName: '',
                    description: '',
                    amount: '',
                    transactionType: ''
                }
            },
            methods: {
                addTransaction: function () {
                    var payload = {
                        VendorName: this.addTransactionCommand.vendorName,
                        TransactionType: this.addTransactionCommand.transactionType,
                        Description: this.addTransactionCommand.description,
                        Amount: this.addTransactionCommand.amount
                    };

                    axios.post('/transactions/addtransaction', payload);
                }
            }
        });
    }
}());
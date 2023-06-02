// Variables to store transactions
let transactions = [];

// Function to add a new transaction
function addTransaction(event) {
    event.preventDefault();

    const type = document.getElementById('transaction-type').value;
    const description = document.getElementById('transaction-description').value;
    const amount = parseFloat(document.getElementById('transaction-amount').value);

    if (description.trim() === '' || isNaN(amount)) {
        return;
    }

    const transaction = {
        type,
        description,
        amount
    };

    transactions.push(transaction);

    updateTable();
    updateBalance();

    document.getElementById('transaction-description').value = '';
    document.getElementById('transaction-amount').value = '';
}

// Function to delete a transaction
function deleteTransaction(index) {
    transactions.splice(index, 1);
    updateTable();
    updateBalance();
}

// Function to update the transaction table
function updateTable() {
    const tableBody = document.querySelector('#transaction-table tbody');
    tableBody.innerHTML = '';

    transactions.forEach((transaction, index) => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${transaction.type}</td>
            <td>${transaction.description}</td>
            <td>${transaction.amount}</td>
            <td><button onclick="deleteTransaction(${index})">Delete</button></td>
        `;

        tableBody.appendChild(row);
    });
}

// Function to update the balance
function updateBalance() {
    const balance = transactions.reduce((total, transaction) => {
        if (transaction.type === 'income') {
            return total + transaction.amount;
        } else {
            return total - transaction.amount;
        }
    }, 0);

    const balanceElement = document.getElementById('balance');
    balanceElement.textContent = `Balance: $${balance.toFixed(2)}`;
}

// Event listener for form submission
document.getElementById('transaction-form').addEventListener('submit', addTransaction);

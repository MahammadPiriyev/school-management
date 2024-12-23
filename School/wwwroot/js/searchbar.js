document.getElementById('search-bar').addEventListener('input', function () {
    const searchText = this.value.toLowerCase(); // Get the search input and convert to lowercase
    const rows = document.querySelectorAll('table tbody tr'); // Select all rows in the table body

    rows.forEach(row => {
        const rowText = row.textContent.toLowerCase(); // Get the row's text content and convert to lowercase
        if (rowText.includes(searchText)) {
            row.style.display = ''; // Show the row if it matches the search
        } else {
            row.style.display = 'none'; // Hide the row if it doesn't match
        }
    });
});

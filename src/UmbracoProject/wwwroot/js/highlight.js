let current = 0;
for (var i = 0; i < document.links.length; i++) {
    if (document.links[i].href === document.URL) {
        current = i;
    }
}

// Change language buttons background color
var bgBtn = document.getElementById('bg-btn');
var enBtn = document.getElementById('en-btn');

if (document.links[current].href.includes('/bg/')) {
    bgBtn.style.backgroundColor = 'black';
    bgBtn.style.color = 'white';

    bgBtn.disabled = true;
}
else {
    enBtn.style.backgroundColor = 'black';
    enBtn.style.color = 'white';

    enBtn.disabled = true;
}


// Highlight current page at header

if (document.links[current].className !== "site-name") {
    document.links[current].className = 'current';
}
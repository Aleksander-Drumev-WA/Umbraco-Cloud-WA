let current = 0;
for (var i = 0; i < document.links.length; i++) {
    if (document.links[i].href === document.URL) {
        current = i;
    }
}

// Change language buttons background color
var bgBtn = document.getElementById('bg-btn');
var enBtn = document.getElementById('en-btn');
if (!getCurrentURL().includes('/blog-posts-container/') && !getCurrentURL().includes('/categories/')) {

    if (document.links[current].href.includes('/bg/')) {
        bgBtn.style.backgroundColor = 'black';
        bgBtn.style.color = 'white';
    }
    else {
        enBtn.style.backgroundColor = 'black';
        enBtn.style.color = 'white';
    }
}
else {
    // Disable if url is in article
    bgBtn.disabled = true;
    enBtn.disabled = true;
}


// Highlight current page at header

if (document.links[current].className !== "site-name") {
    document.links[current].className = 'current';
}


// Change language dynamically

function changeLanguage(e) {
    let url = getCurrentURL();

    if (!url.includes('/blog-posts-container/')) {

        if (e.target.id === 'en-btn' && url.includes('/bg/')) {
            url = url.replace('/bg/', '/en/');
        }
        else if (e.target.id === "bg-btn" && url.includes('/en/')) {
            url = url.replace('/en/', '/bg/');
        }

        window.location.href = url;
    }


}

function getCurrentURL() {
    return window.location.href
}
document.addEventListener("DOMContentLoaded", function () {
    var toggle = document.querySelector("[data-menu-toggle]");
    var overlay = document.querySelector(".sidebar-overlay");

    function setSidebarOpen(open) {
        document.body.classList.toggle("sidebar-open", open);
    }

    if (toggle) {
        toggle.addEventListener("click", function () {
            setSidebarOpen(!document.body.classList.contains("sidebar-open"));
        });
    }

    if (overlay) {
        overlay.addEventListener("click", function () {
            setSidebarOpen(false);
        });
    }

    document.querySelectorAll(".side-link").forEach(function (link) {
        link.addEventListener("click", function () {
            if (window.matchMedia("(max-width: 991.98px)").matches) {
                setSidebarOpen(false);
            }
        });
    });

    document.querySelectorAll("[data-demo-autocomplete]").forEach(function (input) {
        var menu = document.querySelector(input.dataset.demoAutocomplete);
        if (!menu) {
            return;
        }

        var values = (input.dataset.values || "").split("|").filter(Boolean);

        input.addEventListener("input", function () {
            var term = input.value.trim().toLowerCase();
            menu.innerHTML = "";

            if (term.length < 2) {
                menu.style.display = "none";
                return;
            }

            var matches = values.filter(function (value) {
                return value.toLowerCase().includes(term);
            }).slice(0, 6);

            matches.forEach(function (match) {
                var item = document.createElement("button");
                item.type = "button";
                item.className = "autocomplete-item";
                item.textContent = match;
                item.addEventListener("click", function () {
                    input.value = match;
                    menu.style.display = "none";
                });
                menu.appendChild(item);
            });

            menu.style.display = matches.length ? "block" : "none";
        });

        document.addEventListener("click", function (event) {
            if (!input.contains(event.target) && !menu.contains(event.target)) {
                menu.style.display = "none";
            }
        });
    });
});

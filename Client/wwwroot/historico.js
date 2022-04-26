(function () {
    window.voltar = () => {
        if (window.location.href !== "https://localhost:44388/") {
            window.history.back();
        }
    };
})();
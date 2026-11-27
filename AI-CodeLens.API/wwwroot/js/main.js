
import {
    codeInput,
    reviewButton,
    documentationButton,
    findingsList,
    documentationResult,
    findingCount,
    fileInput,
    newReviewButton,
    fileNameDisplay,
    editorFileName,
    reviewStatus,
    criticalBadge,
    warningBadge,
    infoBadge
} from "./dom.js";

import {
    updateLineCount,
    renderFindings
} from "./ui.js";

import {
    renderHistory,
    saveToHistory
} from "./history.js";

import {
    reviewCode,
    generateDocumentation
} from "./api.js";

codeInput.addEventListener("input", updateLineCount);

newReviewButton.addEventListener("click", () => {
    codeInput.value = "";
    fileInput.value = "";

    fileNameDisplay.textContent = "Untitled-1";
    editorFileName.textContent = "Kaynak / Untitled-1";

    documentationResult.textContent = "";
    findingCount.textContent = "0";

    criticalBadge.textContent = "0 Kritik";
    warningBadge.textContent = "0 Uyarı";
    infoBadge.textContent = "0 Bilgi";

    findingsList.replaceChildren();

    const empty = document.createElement("div");
    empty.className = "empty-state";
    empty.textContent =
        "Kodunuzu inceleyerek sonuçları burada görebilirsiniz.";

    findingsList.appendChild(empty);

    reviewStatus.querySelector("strong").textContent =
        "İncelemeye hazır";

    reviewStatus.querySelector("small").textContent =
        "Kodunuzu analiz etmek için butona basın.";

    updateLineCount();
    renderHistory();
});

reviewButton.addEventListener("click", async () => {
    const code = codeInput.value.trim();

    if (!code) {
        alert("Lütfen incelemek için kod girin.");
        return;
    }

    reviewButton.disabled = true;
    reviewButton.textContent = "İnceleniyor...";

    findingsList.replaceChildren();

    const loading = document.createElement("div");
    loading.className = "empty-state";
    loading.textContent = "Yapay zekâ kodunuzu inceliyor...";
    findingsList.appendChild(loading);

    try {
        const result = await reviewCode(code);
        const findings = result.findings || [];

        fileNameDisplay.textContent =
            result.fileName || fileNameDisplay.textContent;

        editorFileName.textContent =
            `Kaynak / ${fileNameDisplay.textContent}`;

        renderFindings(findings);
        saveToHistory(code, findings);

        reviewStatus.querySelector("strong").textContent =
            "İnceleme tamamlandı";

        reviewStatus.querySelector("small").textContent =
            `${findings.length} bulgu bulundu.`;

    } catch (error) {
        findingsList.replaceChildren();

        const errorMessage = document.createElement("div");
        errorMessage.className = "empty-state";
        errorMessage.textContent = `Hata: ${error.message}`;

        findingsList.appendChild(errorMessage);

    } finally {
        reviewButton.disabled = false;
        reviewButton.textContent = "Kodu İncele";
    }
});

documentationButton.addEventListener("click", async () => {
    const code = codeInput.value.trim();

    if (!code) {
        alert("Lütfen belgelenecek kodu girin.");
        return;
    }

    documentationButton.disabled = true;
    documentationButton.textContent =
        "Dokümantasyon hazırlanıyor...";

    documentationResult.textContent =
        "Yapay zekâ dokümantasyon oluşturuyor...";

    try {
        const result = await generateDocumentation(
            code,
            fileNameDisplay.textContent.trim()
        );

        documentationResult.textContent =
            result.documentation || "Dokümantasyon oluşturulamadı.";

    } catch (error) {
        documentationResult.textContent =
            `Hata: ${error.message}`;

    } finally {
        documentationButton.disabled = false;
        documentationButton.textContent =
            "Dokümantasyon Oluştur";
    }
});

fileInput.addEventListener("change", async (event) => {
    const file = event.target.files[0];

    if (!file) return;

    try {
        codeInput.value = await file.text();

        fileNameDisplay.textContent = file.name;
        editorFileName.textContent =
            `Kaynak / ${fileNameDisplay.textContent}`;

        updateLineCount();

    } catch {
        alert("Dosya okunamadı.");
    }
});

updateLineCount();
renderHistory();

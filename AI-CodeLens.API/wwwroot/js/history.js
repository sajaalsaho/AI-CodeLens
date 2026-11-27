
import {
    codeInput,
    documentationResult,
    historyList,
    historyCount,
    fileNameDisplay,
    editorFileName,
    reviewStatus
} from "./dom.js";

import {
    updateLineCount,
    renderFindings
} from "./ui.js";

let reviewHistory = [];

export function renderHistory() {
    historyList.replaceChildren();

    historyCount.textContent = reviewHistory.length;

    if (reviewHistory.length === 0) {
        const empty = document.createElement("div");
        empty.className = "empty-state";
        empty.textContent = "Henüz inceleme geçmişi bulunmuyor.";
        historyList.appendChild(empty);
        return;
    }

    reviewHistory.forEach(item => {
        const historyItem = document.createElement("div");
        historyItem.className = "history-item";

        if (item.id === reviewHistory[0].id) {
            historyItem.classList.add("selected");
        }

        const title = document.createElement("strong");
        title.textContent = item.fileName;

        const details = document.createElement("span");
        details.textContent = `${item.findings.length} bulgu`;

        const date = document.createElement("small");
        date.textContent = item.time;

        historyItem.append(title, details, date);

        historyItem.addEventListener("click", () => {
            codeInput.value = item.code;
            fileNameDisplay.textContent = item.fileName;
            editorFileName.textContent = `Kaynak / ${item.fileName}`;

            updateLineCount();
            renderFindings(item.findings);

            reviewStatus.querySelector("strong").textContent =
                "✓ Önceki inceleme açıldı";

            reviewStatus.querySelector("small").textContent =
                `${item.findings.length} bulgu bulundu.`;

            documentationResult.textContent = "";

            reviewHistory.forEach(entry => {
                entry.selected = entry.id === item.id;
            });

            renderHistory();
        });

        if (item.selected) {
            historyItem.classList.add("selected");
        }

        historyList.appendChild(historyItem);
    });
}

export function saveToHistory(code, findings) {
    const item = {
        id: Date.now() + Math.random(),
        code: code,
        findings: findings,
        fileName: fileNameDisplay.textContent.trim(),
        time: "Az önce",
        selected: true
    };

    reviewHistory.forEach(entry => {
        entry.selected = false;
    });

    reviewHistory.unshift(item);

    renderHistory();
}

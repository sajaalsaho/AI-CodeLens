// Ekrana çizim yapan fonksiyonlar

import {
    codeInput,
    findingsList,
    findingCount,
    lineInfo,
    criticalBadge,
    warningBadge,
    infoBadge
} from "./dom.js";

// Satır sayısını güncelle
export function updateLineCount() {
    const code = codeInput.value;
    const lines = code.length === 0 ? 0 : code.split("\n").length;
    lineInfo.textContent = `${lines} satır`;
}

// Bulgu önem derecesini düzenle
function normalizeSeverity(severity) {
    const value = (severity || "").toLowerCase();

    if (value.includes("critical") || value.includes("kritik")) {
        return "critical";
    }

    if (value.includes("warning") || value.includes("uyarı")) {
        return "warning";
    }

    return "info";
}

// Bulgu kartı oluştur
function createFindingCard(finding) {
    const card = document.createElement("div");
    card.className = "finding-card";

    const title = document.createElement("h4");
    title.textContent = finding.title || "Kod İnceleme Bulgusu";

    const description = document.createElement("p");
    description.textContent = finding.description || "";

    const severity = document.createElement("small");
    severity.textContent =
        `Önem: ${finding.severity || "Belirtilmedi"} | Satır: ${finding.lineNumber ?? 0}`;

    const recommendation = document.createElement("p");
    recommendation.textContent =
        `Öneri: ${finding.recommendation || "Öneri bulunmuyor."}`;

    card.append(title, description, severity, recommendation);

    return card;
}

// Bulgu sonuçlarını ekrana yazdır
export function renderFindings(findings) {
    findingsList.replaceChildren();

    findingCount.textContent = findings.length;

    let criticalCount = 0;
    let warningCount = 0;
    let infoCount = 0;

    findings.forEach(finding => {
        const severity = normalizeSeverity(finding.severity);

        if (severity === "critical") criticalCount++;
        else if (severity === "warning") warningCount++;
        else infoCount++;

        findingsList.appendChild(createFindingCard(finding));
    });

    criticalBadge.textContent = `${criticalCount} Kritik`;
    warningBadge.textContent = `${warningCount} Uyarı`;
    infoBadge.textContent = `${infoCount} Bilgi`;

    if (findings.length === 0) {
        const empty = document.createElement("div");
        empty.className = "empty-state";
        empty.textContent = "Herhangi bir bulgu bulunamadı.";
        findingsList.appendChild(empty);
    }
}


import { API_BASE_URL } from "./config.js";

async function postJson(path, body) {
    const response = await fetch(`${API_BASE_URL}${path}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(body)
    });

    if (!response.ok) {
        throw new Error(`İstek başarısız: HTTP ${response.status}`);
    }

    return response.json();
}

export function reviewCode(code) {
    return postJson("/api/CodeReview", { code });
}

export function generateDocumentation(code, fileName) {
    return postJson("/api/CodeDocumentation", {
        code: code,
        fileName: fileName
    });
}

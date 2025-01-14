import LineChartComponent from "../Charts/LineChartComponent";
import PieChartComponent from "../Charts/PieChartComponent";

export default function Square() {
    return (
        <>
            <div style={{ padding: '20px' }}>
                <h1>Sales 2004:2023</h1>
                <LineChartComponent />
            </div>

            <div style={{ padding: '20px' }}>
                <h1>Sales Percentage</h1>
                <PieChartComponent />
            </div>
        </>
    );
}
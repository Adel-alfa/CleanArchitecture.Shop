
import React from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

const data = [
    { name: 'Jan', 2023: 4000, 2024: 2400},
    { name: 'Feb', 2023: 3000, 2024: 1398},
    { name: 'Mar', 2023: 2000, 2024: 9800},
    { name: 'Apr', 2023: 2780, 2024: 3908},
    { name: 'May', 2023: 1890, 2024: 4800},
    { name: 'Jun', 2023: 2390, 2024: 3800},
    { name: 'Jul', 2023: 3490, 2024: 4300},
];

const LineChartComponent: React.FC = () => {
    return (
        <ResponsiveContainer width="100%" height={400}>
            <LineChart
                width={500}
                height={300}
                data={data}
                margin={{ top: 5, right: 30, left: 20, bottom: 5 }}
            >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="name" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Line type="monotone" dataKey="2024" stroke="#8884d8" />
                <Line type="monotone" dataKey="2023" stroke="#82ca9d" />               
            </LineChart>
        </ResponsiveContainer>
    );
};

export default LineChartComponent;
